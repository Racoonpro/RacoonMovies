using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;

namespace Racoon.Movies.Web.Controllers;

[ApiController]
[Route("api/comment")]
public class CommentController : ControllerBase
{
    private readonly RacoonMoviesDbContext _context;
    public CommentController(RacoonMoviesDbContext context)
    {
        _context = context;
    }

    [HttpGet("movie/{movieId:int}")]
    public async Task<IActionResult> ListAllAsync(int movieId)
    {
        var comments = await _context.Comments.Where(x => x.MovieId == movieId).ToListAsync();
        return Ok(comments);
    }
}