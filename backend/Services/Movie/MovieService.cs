using System.Collections;

namespace Kinopoisk.Services.Movie;


public class MovieService : IMovieService {
    public Task<List<GetMovieDTO>> AddMovie(AddMovieDTO addMoviceDTO)
    {
        throw new NotImplementedException();
    }

    public Task<Hashtable> DeleteCharacter(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetMovieDTO>> GetMovie(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<GetMovieDTO>> GetMovies()
    {
        throw new NotImplementedException();
    }

    public Task<List<GetMovieDTO>> UpdateMovie(UpdateMovieDTO updateMovieDTO)
    {
        throw new NotImplementedException();
    }
}