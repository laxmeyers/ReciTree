namespace ReciTree.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            Recipe recipe = _repo.CreateRecipe(recipeData);
            return recipe;
        }

        internal Recipe GetOneRecipe(int id, string userId)
        {
            Recipe recipe = _repo.getOneRecipe(id);
            if (recipe == null) throw new Exception("Doesn't exist");
            if (recipe.IsPrivate || userId != recipe.CreatorId) throw new Exception("Can't retrive that right now");
            return recipe;
        }

        internal List<Recipe> GetRecipes(string userId)
        {
            List<Recipe> recipes = _repo.GetRecipes();
            recipes = recipes.FindAll(r => r.CreatorId == userId || !r.IsPrivate);
            return recipes;
        }
    }
}