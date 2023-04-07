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


        [HttpPost]
        [Authorize]

        public async Task<ActionResult<Ingredient>> CreateIngredientForRecipe([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

                Ingredient ingredient = _ingredientsService.CreateIngredientForRecipe(ingredientData, userInfo);
                return ingredient;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredientFromRecipe(int id){
        try 
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            string message = _ingredientsService.DeleteIngredientFromRecipe(id, userInfo);
            return message;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]

    public async Task<ActionResult<Ingredient>> UpdateIngredient([FromBody] Ingredient updata, int id){
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        updata.Id = id;
        Ingredient ingredient = _ingredientsService.UpdateIngredient(updata, userInfo);
        return ingredient;
    }


    }
}