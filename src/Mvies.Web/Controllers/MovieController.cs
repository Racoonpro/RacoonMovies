using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;
using Racoon.Moovies.DbContext.Models;

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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        return Ok(movie);
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListAsync()
    {
        var movies = await _context.Movies.ToListAsync();
        return Ok(movies);
    }

    [HttpPost]
    public async Task<IActionResult> NewAsync([FromBody] Movie movie)
    {
        if (movie == null)
            throw new InvalidOperationException("Unable to add movie.");

        movie.Comments = null!;
        await  _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();

        return Ok(movie);
    }
}