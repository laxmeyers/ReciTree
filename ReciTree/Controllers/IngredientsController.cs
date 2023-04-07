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
  }
}