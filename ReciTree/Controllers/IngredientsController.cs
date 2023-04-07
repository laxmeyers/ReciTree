namespace ReciTree.Controllers
{
  [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientsService _ingredientsService;
        private readonly Auth0Provider _auth;

    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
      _ingredientsService = ingredientsService;
      _auth = auth;
    }


    [HttpPost("{recipeId}")]
    [Authorize]

    public async Task<ActionResult<Ingredient>> CreateIngredientForRecipe([FromBody] Ingredient ingredientData, int recipeId){
        try 
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            
            Ingredient ingredient = _ingredientsService.CreateIngredientForRecipe(ingredientData, recipeId, userInfo);
            return ingredient;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public Task<ActionResult<List<Ingredient>>> GetIngredientsForRecipe(){
        try 
        {
            
        }
        catch (Exception e)
        {
            return Task.FromResult(BadRequest(e.Message));
        }
    }
    


    }
}