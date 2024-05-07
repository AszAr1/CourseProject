namespace Kinopoisk.DTOs.Movie;

public class GetMovieDTO {
    public string Uri { get; set; } = "";
    public MovieInfoModel? MovieInfo { get; set; }
}