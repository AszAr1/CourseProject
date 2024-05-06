using System.Collections;
namespace Kinopoisk.Services.Movie;

public interface IMovieService {
    Task<List<GetMovieDTO>> GetMovies();
    Task<List<GetMovieDTO>> GetMovie(int id);
    Task<List<GetMovieDTO>> AddMovie(AddMovieDTO addMoviceDTO);
    Task<List<GetMovieDTO>> UpdateMovie(UpdateMovieDTO updateMovieDTO);
    Task<Hashtable> DeleteCharacter(int id);
}