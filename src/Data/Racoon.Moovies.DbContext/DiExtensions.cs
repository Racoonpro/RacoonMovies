using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Racoon.Moovies.DbContext;
public static class DiExtensions
{

    public static IServiceCollection RegisterInMemoryDb(this IServiceCollection services)
    {
        services
            .AddDbContext<RacoonMoviesDbContext>(
                opts => opts.UseInMemoryDatabase(databaseName: "RacoonMovies")
            );
        return services;
    }
}