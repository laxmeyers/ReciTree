namespace ReciTree.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BranchesController : ControllerBase
    {
        private readonly BranchesService _branchesService;
        private readonly Auth0Provider _auth;

        public BranchesController(BranchesService branchesService, Auth0Provider auth)
        {
            _branchesService = branchesService;
            _auth = auth;
        }
    }
}