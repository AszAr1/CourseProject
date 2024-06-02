using System.Collections;
namespace Kinopoisk.Services.Movie;

public interface IMovieService {
    Task<List<GetMovieDTO>> GetMovies();
    Task<GetMovieDTO> GetMovie(string name);
    Task<GetMovieDTO> CreateMovie(CreateUpdateMovieDTO createMovieDTO);
    Task<GetMovieDTO> UpdateMovie(CreateUpdateMovieDTO updateMovieDTO);
    Task<Hashtable> DeleteMovie(string name);
}