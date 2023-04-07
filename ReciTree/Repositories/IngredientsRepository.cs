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

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId)
    {
      throw new NotImplementedException();
    }
  }
}