using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;

namespace Racoon.Movies.Web.Controllers;

[Route("api/{movieId}")]
public class MovieVisitController : ControllerBase
{
    private readonly RacoonMoviesDbContext _context;
    public MovieVisitController(RacoonMoviesDbContext context)
    {
        _context = context;
    }

    [HttpGet("count")]
    public async Task<IActionResult> VisitsCount(int movieId)
    {
        var visits = await _context.MovieVisits.CountAsync(x => x.MovieId == movieId);
        return Ok(visits);
    }
}