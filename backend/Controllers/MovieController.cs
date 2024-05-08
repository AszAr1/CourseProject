using Microsoft.AspNetCore.Mvc;

namespace Kinopoisk.Controllers {
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase {
        private readonly IMovieService movieService;
        public MovieController(IMovieService mS)  {
            movieService = mS;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetMovieDTO>>> Index() => 
            Ok(await movieService.GetMovies());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetMovieDTO>> Get(int id) => 
            Ok(await movieService.GetMovie(id));

        [HttpPost("create")]
        public async Task<ActionResult<GetMovieDTO>> Create(CreateMovieDTO addMovieDTO) => 
            Ok(await movieService.AddMovie(addMovieDTO));

        
    }
}