using AutoMapper;

namespace Kinopoisk;

public class AutoMapperProfile : Profile {
    public AutoMapperProfile() {
        CreateMap<MovieModel, GetMovieDTO>();
        CreateMap<CreateUpdateMovieDTO, MovieModel>();

        CreateMap<CreateUpdateMovieInfoDTO, MovieInfoModel>();
        CreateMap<MovieInfoModel, GetMovieInfoDTO>();

        CreateMap<CountryDTO, CountryModel>(); 
        CreateMap<CountryModel, CountryDTO>();

        CreateMap<GenreDTO, GenreModel>();
        CreateMap<GenreModel, GenreDTO>();

        CreateMap<UserModel, GetUserDTO>();
        CreateMap<UpdateUserDTO, UserModel>();
        CreateMap<CreateUserDTO, UserModel>();
    }
}