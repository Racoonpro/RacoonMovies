namespace Racoon.Moovies.DbContext.Models;

public class Comment : BaseEntity
{
    public int MovieId { get; set; }
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Movie Movie { get; set; }
}