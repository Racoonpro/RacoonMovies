namespace Racoon.Moovies.DbContext.Models;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedTime { get; set; }
    public string UpdatedBy { get; set; } = string.Empty;
    public DateTime? UpdatedTime { get; set; }
}