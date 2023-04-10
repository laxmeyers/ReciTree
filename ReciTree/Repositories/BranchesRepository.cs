namespace ReciTree.Repositories
{
    public class BranchesRepository
    {
        private readonly IDbConnection _db;

        public BranchesRepository(IDbConnection db)
        {
            _db = db;
        }
    }
}