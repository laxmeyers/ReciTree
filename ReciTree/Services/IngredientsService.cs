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

    internal string DeleteIngredientFromRecipe(int id, Account userInfo)
    {
        Ingredient ingredient = this.GetIngredientById(id);
        Recipe recipe = _recipeService.GetOneRecipe(ingredient.RecipeId, userInfo.Id);
        if(recipe.CreatorId != userInfo.Id)throw new Exception("Not your recipe to delete ingredients from");
        if(recipe == null) throw new Exception("nice try man");
        int rows = _repo.DeleteIngredientFromRecipe(id);
        if(rows != 1) throw new Exception($"something went wrong {rows} ingredients were deleted check your DB");
        return $"{ingredient.Name} has been removed from {recipe.Name}";
    }

    internal List<Ingredient> GetIngredientsForRecipe(int recipeId, string userId)
    {
        Recipe recipe = _recipeService.GetOneRecipe(recipeId, userId);
        if(recipe == null) throw new Exception("errer error errrrr");
        List<Ingredient> ingredients = _repo.GetIngredientsForRecipe(recipeId);
        return ingredients;
    }

    internal Ingredient GetIngredientById(int id){
        Ingredient ingredient = _repo.GetIngredientById(id);
        if(ingredient == null) throw new Exception("No ingredient at tha id man try again");
        return ingredient;
    }
    }
}