using AutoMapper;

namespace TestAPI;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<MovieModel, GetMovieDTO>();
        CreateMap<CreateMovieDTO, MovieModel>();
        CreateMap<UpdateMovieDTO, MovieModel>();
    }
}