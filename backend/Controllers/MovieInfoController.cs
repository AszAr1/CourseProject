using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers;

[ApiController]
[Route("moviesInfos")]
public class MovieInfoController : ControllerBase {
    private readonly IMovieInfoService movieInfoService;
    
    public MovieInfoController(IMovieInfoService mS)  {
        movieInfoService = mS;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetMovieDTO>>> Index() => 
        Ok(await movieInfoService.GetMovieInfos());

    [HttpGet("{name}")]
    public async Task<ActionResult<GetMovieDTO>> Get(string name) => 
        Ok(await movieInfoService.GetMovieInfo(name));

    [HttpPost("create")]
    public async Task<ActionResult<GetMovieDTO>> Create(CreateMovieInfoDTO createMovieInfoDTO) => 
        Ok(await movieInfoService.CreateMovieInfo(createMovieInfoDTO));
}