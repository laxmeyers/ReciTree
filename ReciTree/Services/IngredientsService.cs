namespace ReciTree.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _repo;
        private readonly RecipesService _recipeService;

    public IngredientsService(IngredientsRepository repo, RecipesService recipeService)
    {
        _repo = repo;
        _recipeService = recipeService;
    }

    internal Ingredient CreateIngredientForRecipe(Ingredient ingredientData, Account userInfo)
    {
        Recipe recipe  = _recipeService.GetOneRecipe(ingredientData.RecipeId, userInfo.Id);
        if(recipe == null) throw new Exception("something happened in the ingredients service");
        Ingredient ingredient = _repo.CreateIngredientForRecipe(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId, string userId)
    {
        Recipe recipe = _recipeService.GetOneRecipe(recipeId, userId);
        if(recipe == null) throw new Exception("errer error errrrr");
        List<Ingredient> ingredients = _repo.GetIngredientsForRecipe(recipeId);
        return ingredients;
    }
    }
}