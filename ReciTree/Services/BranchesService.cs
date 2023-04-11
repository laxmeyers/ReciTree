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

        internal List<Branch> GetAllBranches(string userId)
        {
            List<Branch> branches = _repo.GetAllBranches();
            branches = branches.FindAll(b => b.IsPrivate == false || b.CreatorId == userId);
            return branches;
        }
    }
}