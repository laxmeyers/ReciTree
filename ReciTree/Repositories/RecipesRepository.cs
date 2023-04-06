namespace ReciTree.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            insert into recipes
            (name, instructions, instructionsPic, creatorId, isPrivate, img, category)
            values
            (@name,@instructions,@instructionsPic,@creatorId,@isPrivate,@img,@category);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal int DeleteRecipe(int id)
        {
            string sql = @"
            Delete
            from recipes 
            where id = @id;
            ";
            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal Recipe getOneRecipe(int id)
        {
            string sql = @"
            SELECT 
            rec.*,
            acc.*
            from recipes rec
            JOIN accounts acc ON rec.creatorId = acc.id 
            WHERE
            rec.id = @id;
            ";
            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
            {
                recipe.Creator = profile;
                return recipe;
            }, new { id }).FirstOrDefault();
            return recipe;
        }

        internal List<Recipe> GetRecipes()
        {
            string sql = @"
            Select 
            rec.*,
            acc.* 
            from recipes rec
            join accounts acc on acc.id = rec.creatorId;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (rec, prof) =>
            {
                rec.Creator = prof;
                return rec;
            }).ToList();
            return recipes;
        }

        internal int UpdateRecipe(Recipe original)
        {
            string sql = @"
            UPDATE recipes
            set
            name = @name,
            img = @img,
            category = @category,
            instructions = @instructions,
            instructionsPic = @instructionsPic
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, original);
            return rows;
        }
    }
}