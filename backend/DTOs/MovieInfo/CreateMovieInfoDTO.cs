namespace Kinopoisk.DTOs.MovieInfo;

public class CreateMovieInfoDTO {
    public string NameRu { get; set; } = "";
    public string? NameEn { get; set; }
    public MediaType Type { get; set; }
    public int Year { get; set; }
    public string Description { get; set; } = "";
    public string FilmLength { get; set; } = "";
    public List<Dictionary<string, string>> Countries { get; set; } = new List<Dictionary<string, string>>();    
    public List<Dictionary<string, string>> Genres { get; set; } = new List<Dictionary<string, string>>();    
    public double Rating { get; set; }
    public string PosterUrl { get; set; } = "";
    public string PosterUrlPreview { get; set; } = "";   
}