using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;

namespace Racoon.Movies.Web.Controllers;

[ApiController]
[Route("api/movie")]
public class MovieController: ControllerBase
{
    private readonly RacoonMoviesDbContext _context;
    public MovieController(RacoonMoviesDbContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAsync()
    {
        var movies = await _context.Movies.ToListAsync();
        return Ok(movies);
    }
}