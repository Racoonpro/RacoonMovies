using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext.Models;

namespace Racoon.Moovies.DbContext;

public class RacoonMoviesDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public RacoonMoviesDbContext(DbContextOptions<RacoonMoviesDbContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var changedOrAddedEntities = ChangeTracker.Entries()
            .Where(x => x.State is EntityState.Added or EntityState.Modified)
            .ToList();

        foreach (var entity in changedOrAddedEntities)
        {
            var @base = (BaseEntity)entity.Entity;
            @base.CreatedBy = "Kiryl";
            @base.CreatedTime = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" },
            new Movie { Id = 2, Name = "Movie1", Description = "Description fo movie1", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" },
            new Movie { Id = 3, Name = "Comment Movie", Description = "Movie to test comments", CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" }
            );

        modelBuilder.Entity<Comment>().HasData(
            new Comment { Id = 1, MovieId = 3, Text = "The best movie ever", Rating = 5, CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" }
        );
        modelBuilder.Entity<Comment>().HasData(
            new Comment { Id = 2, MovieId = 3, Text = "Loved this movie here", Rating = 3, CreatedTime = DateTime.UtcNow, CreatedBy = "Kiryl" }
        );

    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<MovieVisit> MovieVisits { get; set; }
}