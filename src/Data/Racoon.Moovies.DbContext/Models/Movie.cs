namespace Racoon.Moovies.DbContext.Models;

public class Movie : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<Comment> Comments { get; set; }
}