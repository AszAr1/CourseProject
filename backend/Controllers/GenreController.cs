using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers;

[ApiController]
[Route("genres")]
public class GenreController : ControllerBase {
    private readonly IGenreService genreService;
    public GenreController(IGenreService gS) {
        genreService = gS;
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreDTO>>> Index() => 
        Ok(await genreService.GetGenres());

    [HttpGet("{name}")]
    public async Task<ActionResult<GenreDTO>> Get(string name) => 
        Ok(await genreService.GetGenre(name));

    [HttpPost("create")]
    public async Task<ActionResult<GenreDTO>> Create(GenreDTO genreDTO) => 
        Ok(await genreService.AddGenre(genreDTO));
}