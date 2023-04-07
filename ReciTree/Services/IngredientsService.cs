namespace ReciTree.Services
{
  public class IngredientsService
    {
        private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
      _repo = repo;
    }
  }
}