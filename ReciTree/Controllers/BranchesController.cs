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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Branch>> CreateBranch([FromBody] Branch branchData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                branchData.CreatorId = userInfo.Id;
                Branch branch = _branchesService.CreateBranch(branchData);
                branch.Creator = userInfo;
                return Ok(branch);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Branch>>> GetAllBranches()
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                List<Branch> branches = _branchesService.GetAllBranches(userInfo?.Id);
                return Ok(branches);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}