namespace ReciTree.Models
{
    public class Recipe : RepoItem<int>
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string InstructionsPic { get; set; }
        public string CreatorId { get; set; }
        public string Img { get; set; }
        public string Category { get; set; }
        public Boolean IsPrivate { get; set; } = false;
        public Profile Creator { get; set; }
    }
}