namespace ReciTree.Repositories
{
    public class BranchesRepository
    {
        private readonly IDbConnection _db;

        public BranchesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Branch CreateBranch(Branch branchData)
        {
            string sql = @"
            insert into branches
            (name,creatorId,description,img,isPrivate)
            values
            (@name,@creatorId,@description,@img,@isPrivate);
            Select LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, branchData);
            branchData.Id = id;
            return branchData;
        }
    }
}