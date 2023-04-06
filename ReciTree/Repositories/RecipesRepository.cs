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
            * 
            from recipes;
            ";
            List<Recipe> recipes = _db.Query<Recipe>(sql).ToList();
            return recipes;
        }
    }
}