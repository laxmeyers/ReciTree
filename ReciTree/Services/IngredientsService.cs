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

    internal Ingredient CreateIngredientForRecipe(Ingredient ingredientData, int recipeId, Account userInfo)
    {
        Recipe recipe  = _recipeService.GetOneRecipe(recipeId, userInfo.Id);
        if(recipe == null) throw new Exception("something happened in the ingredients service");
        ingredientData.RecipeId = recipeId;
        Ingredient ingredient = _repo.CreateIngredientForRecipe(ingredientData);
        return ingredient;
    }
    }
}