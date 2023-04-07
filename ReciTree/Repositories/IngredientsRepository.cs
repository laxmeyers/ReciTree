namespace ReciTree.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient CreateIngredientForRecipe(Ingredient ingredientData)
        {
            string sql = @"
        INSERT INTO
        ingredients
        (name, measurement, quantity, recipeId)
        VALUE
        (@name, @measurement, @quantity, @recipeId);
        SELECT LAST_INSERT_ID();
        ";

            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
        }

        internal int DeleteIngredientFromRecipe(int id)
        {
            string sql = @"
        DELETE FROM
        ingredients
        WHERE id = @id;
        ";

            int rows = _db.Execute(sql, new { id });
            return rows;
        }

        internal Ingredient GetIngredientById(int id)
        {
            string sql = @"
        SELECT
        * FROM ingredients
        WHERE id  = @id;
        ";

            Ingredient ingredient = _db.Query<Ingredient>(sql, new { id }).FirstOrDefault();
            return ingredient;
        }

        internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
        {
            string sql = @"
        SELECT
        *
        FROM ingredients
        WHERE recipeId = @recipeId;
        ";

            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new { recipeId }).ToList();
            return ingredients;
        }

        internal int UpdateIngredient(Ingredient original)
        {
            string sql = @"
        UPDATE
        ingredients
        SET
        measurement = @measurement,
        quantity = @quantity
        WHERE
        id = @id;

        ";

            int rows = _db.Execute(sql, original);
            return rows;
        }
    }
}