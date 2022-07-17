using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Racoon.Moovies.DbContext;
using Racoon.Moovies.DbContext.Models;
using Racoon.Movies.Web.Models;

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

    [HttpPost("movie/{movieId:int}")]
    public async Task<IActionResult> CreateAsync(int movieId, [FromBody] CommentDto commentDto)
    {
        if (commentDto == null)
            throw new InvalidOperationException("Unable to add movie.");

        var comment = new Comment
        {
            Movie = null!,
            MovieId = movieId,
            Rating = commentDto.Rating,
            Text = commentDto.Text
        };
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return Ok(comment);
    }
}