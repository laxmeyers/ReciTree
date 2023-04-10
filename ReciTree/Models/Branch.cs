namespace ReciTree.Models
{
    public class Branch : RepoItem<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string CreatorId { get; set; }
        public Boolean IsPrivate { get; set; }
        public Profile Creator { get; set; }
    }
}