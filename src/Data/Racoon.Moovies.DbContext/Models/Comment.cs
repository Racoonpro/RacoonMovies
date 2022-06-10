namespace Racoon.Moovies.DbContext.Models;

public class Comment : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Movie Movie { get; set; }
}