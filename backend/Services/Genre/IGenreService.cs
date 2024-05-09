using System.Collections;
namespace Kinopoisk.Services.Genre;

public interface IGenreService {
    Task<List<GenreDTO>> GetGenres();
    Task<GenreDTO> GetGenre(string name);
    Task<GenreDTO> AddGenre(GenreDTO genreDTO);
    Task<GenreDTO> UpdateGenre(GenreDTO genreDTO);
    Task<Hashtable> DeleteGenre(string name);
}