using System.Collections;
namespace Kinopoisk.Services.Movie;

public interface IMovieService {
    Task<List<GetMovieDTO>> GetMovies();
    Task<GetMovieDTO> GetMovie(string name);
    Task<GetMovieDTO> AddMovie(CreateMovieDTO addMovieDTO);
    Task<GetMovieDTO> UpdateMovie(UpdateMovieDTO updateMovieDTO);
    Task<Hashtable> DeleteMovie(string name);
}