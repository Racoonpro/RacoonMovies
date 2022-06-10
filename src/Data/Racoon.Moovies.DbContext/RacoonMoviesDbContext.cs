using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext.Models;

namespace Racoon.Moovies.DbContext;

public class RacoonMoviesDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public RacoonMoviesDbContext(DbContextOptions<RacoonMoviesDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" },
            new Movie { Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" }
            );
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
}