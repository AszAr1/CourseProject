using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers;


[ApiController]
[Route("movies")]
[Authorize]
public class MovieController : ControllerBase {
    private readonly IMovieService movieService;

    public MovieController(IMovieService mS) {
        movieService = mS;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetMovieDTO>>> Index() {
        try
        {
            return Ok(await movieService.GetMovies());
        }
        catch (ArgumentException ex) {
            return BadRequest(new Hashtable{ { "error", ex.Message } });
        }
    }

    [HttpGet("{name}")]
    public async Task<ActionResult<GetMovieDTO>> Get(string name) => 
        Ok(await movieService.GetMovie(name));

    [HttpPost("create")]
    public async Task<ActionResult<GetMovieDTO>> Create(CreateMovieDTO addMovieDTO) => 
        Ok(await movieService.CreateMovie(addMovieDTO));
}