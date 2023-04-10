namespace ReciTree.Services
{
    public class BranchesService
    {
        private readonly BranchesRepository _repo;

        public BranchesService(BranchesRepository repo)
        {
            _repo = repo;
        }

        internal Branch CreateBranch(Branch branchData)
        {
            Branch branch = _repo.CreateBranch(branchData);
            return branch;
        }
    }
}