using Core.Entites;

namespace BlogSite.Models.Entites;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Post> Posts { get; set; }
}