namespace Kinopoisk.DTOs.MovieInfo;

public class GetMovieInfoDTO {
    public int KinopoiskId { get; set; }
    public string NameRu { get; set; } = "";
    public string? NameEn { get; set; }
    public MediaType Type { get; set; }
    public int Year { get; set; }
    public string Description { get; set; } = "";
    public double Rating { get; set; }
    public string PosterUrl { get; set; } = "";
    public string PosterUrlPreview { get; set; } = "";
}