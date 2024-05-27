using System.Collections;

namespace Kinopoisk.Services.MovieInfo;

public interface IMovieInfoService {
    Task<List<GetMovieInfoDTO>> GetMovieInfos();
    Task<GetMovieInfoDTO> GetMovieInfo(string name);
    Task<GetMovieInfoDTO> CreateMovieInfo(CreateMovieInfoDTO createMovieInfoDTO);
    Task<GetMovieInfoDTO> UpdateMovieInfo(UpdateMovieInfoDTO updateMovieInfoDTO);
    Task<Hashtable> DeleteMovieInfo(string name);   
}