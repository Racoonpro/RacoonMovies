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
            new Movie { Id = 1, Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" },
            new Movie { Id = 2, Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" },
            new Movie { Id = 3, Name = "Comment Movie", Description = "Movie to test comments", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" }
            );

        modelBuilder.Entity<Comment>().HasData(
            new Comment {Id = 1, MovieId = 3, Text = "The best movie ever", Rating = 5, CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl"}
        );

    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
}