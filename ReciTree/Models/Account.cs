namespace ReciTree.Models;

public class Account : Profile
{
    public string Email { get; set; }
}

public class Profile : RepoItem<string>
{
    public string Picture { get; set; }
    public string Name { get; set; }
}
