namespace ReciTree.Models
{
  public class Ingredients : RepoItem<int>
    {
        public string Name { get; set; }
        public string Measurement { get; set; }
        public int Quantity { get; set; }
        public int RecipeId { get; set; }

    }
}