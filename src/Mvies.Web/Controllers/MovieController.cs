using Microsoft.AspNetCore.Mvc;

namespace Racoon.Movies.Web.Controllers;

[ApiController]
[Route("api/movie")]
public class MovieController: ControllerBase
{
    public MovieController()
    {
        
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetMovies()
    {

    }
}