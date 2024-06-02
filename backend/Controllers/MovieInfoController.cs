using System.Collections;
using System.Runtime.InteropServices;
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
    public async Task<ActionResult<List<GetMovieDTO>>> Index(
        [FromQuery(Name = "search")] string searchString = "", 
        [FromQuery(Name = "page")] int? page = null) {
        switch (searchString) {
            case "":
                return Ok(await movieInfoService.GetMovieInfos());
            default:
                return Ok(await movieInfoService.Search(searchString, page));
        }
    }

    [HttpGet("filter")]
    public async Task<ActionResult<GetMovieDTO>> Filter([FromQuery] FilterParameters filterParameters) => 
        Ok(await movieInfoService.Filter(filterParameters));
    
    [HttpGet("tops")]
    public async Task<ActionResult<GetMovieDTO>> Filter([FromQuery] TopType type, [FromQuery(Name = "page")] int? page = null) => 
        Ok(await movieInfoService.GetTop(type, page));

    [HttpGet("{name}")]
    public async Task<ActionResult<GetMovieDTO>> Get(string name) => 
        Ok(await movieInfoService.GetMovieInfo(name));
    
    [HttpGet("{name}/staff")]
    public async Task<ActionResult<List<GetStaffDTO>>> GetStaff([FromRoute] string name) => 
        Ok(await movieInfoService.GetStaff(name));
        
    [HttpGet("{name}/actors")]
    public async Task<ActionResult<List<GetStaffDTO>>> GetActors([FromRoute] string name) => 
        Ok(await movieInfoService.GetActors(name));

    [HttpGet("{name}/directors")]
    public async Task<ActionResult<List<GetStaffDTO>>> GetDirectors([FromRoute] string name) => 
        Ok(await movieInfoService.GetDirectors(name));

    [HttpPost("create")]
    public async Task<ActionResult<GetMovieDTO>> Create(CreateUpdateMovieInfoDTO createMovieInfoDTO) => 
        Ok(await movieInfoService.CreateMovieInfo(createMovieInfoDTO));

    [HttpPost("create-with-id")]
    public async Task<ActionResult<GetMovieInfoDTO>> CreateWithKinopoiskId([FromBody] int id) => 
        Ok(await movieInfoService.CreateWithKinopoiskID(id));

    [HttpPatch("{name}/edit")]
    public async Task<ActionResult<GetMovieDTO>> Patch(string name, CreateUpdateMovieInfoDTO createUpdateMovieInfoDTO) => 
        Ok(await movieInfoService.UpdateMovieInfo(createUpdateMovieInfoDTO));
}