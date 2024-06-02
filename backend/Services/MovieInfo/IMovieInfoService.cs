using System.Collections;

namespace Kinopoisk.Services.MovieInfo;

public interface IMovieInfoService {
    Task<List<GetMovieInfoDTO>> GetMovieInfos();
    Task<GetMovieInfoDTO> GetMovieInfo(string name);
    Task<List<GetMovieInfoDTO>> GetTop(TopType type, int? page);
    Task<GetMovieInfoDTO> CreateMovieInfo(CreateUpdateMovieInfoDTO createMovieInfoDTO);
    Task<GetMovieInfoDTO> CreateWithKinopoiskID(int id);
    Task<GetMovieInfoDTO> UpdateMovieInfo(CreateUpdateMovieInfoDTO updateMovieInfoDTO);
    Task<Hashtable> DeleteMovieInfo(string name);   
    Task<List<GetStaffDTO>> GetStaff(string name);
    Task<List<GetStaffDTO>> GetActors(string name);
    Task<List<GetStaffDTO>> GetDirectors(string name);
    Task<List<GetMovieInfoDTO>> Search(string searchString, int? page);
    Task<List<GetMovieInfoDTO>> Filter(FilterParameters parameters);
}
