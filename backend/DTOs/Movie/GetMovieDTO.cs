namespace Kinopoisk.DTOs.Movie;

public class GetMovieDTO {
    public string Uri { get; set; } = "";
    public GetMovieInfoDTO? MovieInfo { get; set; }
}