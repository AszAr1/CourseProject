using AutoMapper;

namespace TestAPI;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<MovieModel, GetMovieDTO>();
        CreateMap<CreateMovieDTO, MovieModel>();
        CreateMap<UpdateMovieDTO, MovieModel>();

        CreateMap<CreateMovieInfoDTO, MovieInfoModel>();
        CreateMap<MovieInfoModel, GetMovieInfoDTO>();

        CreateMap<CountryDTO, CountryModel>();
        CreateMap<CountryModel, CountryDTO>();

        CreateMap<GenreDTO, GenreModel>();
        CreateMap<GenreModel, GenreDTO>();
    }
}