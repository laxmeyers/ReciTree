namespace ReciTree.Repositories
{
  public class IngredientsRepository
    {
        private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}