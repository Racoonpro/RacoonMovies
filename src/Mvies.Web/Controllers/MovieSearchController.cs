using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;

namespace Racoon.Movies.Web.Controllers;

[Route("api/movie/search")]
public class MovieSearchController : ControllerBase
{
    private readonly RacoonMoviesDbContext _ctx;
    public MovieSearchController(RacoonMoviesDbContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    public async Task<IActionResult> StartsWithAsync([FromQuery] string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            var allMovies = await _ctx.Movies.ToListAsync();
            return Ok(allMovies);
        }

        var movies = await _ctx.Movies
            .Where(x => x.Name.StartsWith(query))
            .ToListAsync();
        return Ok(movies);
    }
}