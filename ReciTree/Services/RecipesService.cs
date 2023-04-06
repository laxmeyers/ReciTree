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

        internal Recipe DeleteRecipe(int id, string userId)
        {
            Recipe recipe = this.GetOneRecipe(id, userId);
            _repo.DeleteRecipe(id);
            return recipe;
        }

        internal Recipe GetOneRecipe(int id, string userId)
        {
            Recipe recipe = _repo.getOneRecipe(id);
            if (recipe == null) throw new Exception("Doesn't exist");
            if (recipe.IsPrivate && userId != recipe.CreatorId) throw new Exception("Can't retrive that right now");
            return recipe;
        }

        internal List<Recipe> GetRecipes(string userId)
        {
            List<Recipe> recipes = _repo.GetRecipes();
            recipes = recipes.FindAll(r => r.CreatorId == userId || !r.IsPrivate);
            return recipes;
        }

        internal Recipe UpdateRecipe(int id, Recipe recipeData)
        {
            Recipe original = this.GetOneRecipe(id, recipeData.CreatorId);
            if (original.CreatorId != recipeData.CreatorId) throw new Exception("Not Yours");
            original.Name = recipeData.Name != null ? recipeData.Name : original.Name;
            original.Img = recipeData.Img != null ? recipeData.Img : original.Img;
            original.Instructions = recipeData.Instructions != null ? recipeData.Instructions : original.Instructions;
            original.InstructionsPic = recipeData.InstructionsPic != null ? recipeData.InstructionsPic : original.InstructionsPic;
            original.Category = recipeData.Category != null ? recipeData.Category : original.Category;
            _repo.UpdateRecipe(original);
            return original;

        }
    }
}