namespace ReciTree.Services
{
    public class BranchesService
    {
        private readonly BranchesRepository _repo;

        public BranchesService(BranchesRepository repo)
        {
            _repo = repo;
        }
    }
}