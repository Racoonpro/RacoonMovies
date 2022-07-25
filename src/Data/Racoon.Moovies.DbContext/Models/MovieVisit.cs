namespace Racoon.Moovies.DbContext.Models;

public class MovieVisit : BaseEntity
{
    public DateTime PointInTime { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}