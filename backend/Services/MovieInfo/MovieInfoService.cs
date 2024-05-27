using System.Collections;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Services.MovieInfo;

public class MovieInfoService : IMovieInfoService {
    private readonly DataContext context;
    private IMapper mapper;
    public MovieInfoService(DataContext context, IMapper mapper) {
        this.context = context;
        this.mapper = mapper;
    }
    public async Task<GetMovieInfoDTO> CreateMovieInfo(CreateMovieInfoDTO createMovieInfoDTO) {
        var movieInfo =  mapper.Map<MovieInfoModel>(createMovieInfoDTO);
        context.MovieInfos.Add(movieInfo);
        await context.SaveChangesAsync();
        return mapper.Map<GetMovieInfoDTO>(movieInfo); 
    }

    public Task<Hashtable> DeleteMovieInfo(string name) {
        throw new NotImplementedException();
    }

    public async Task<GetMovieInfoDTO> GetMovieInfo(string name) {
        var movieInfo = await context.MovieInfos.FirstOrDefaultAsync(info => info.NameEn == name);
        return mapper.Map<GetMovieInfoDTO>(movieInfo);
    }

    public async Task<List<GetMovieInfoDTO>> GetMovieInfos() {
        var movieInfos = await context.MovieInfos.ToListAsync();
        return movieInfos.Select(mapper.Map<GetMovieInfoDTO>).ToList();
    }

    public Task<GetMovieInfoDTO> UpdateMovieInfo(UpdateMovieInfoDTO updateMovieInfoDTO) {
        throw new NotImplementedException();
    }
}