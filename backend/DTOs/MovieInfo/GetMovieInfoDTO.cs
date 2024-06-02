namespace Kinopoisk.DTOs.MovieInfo;

public class GetMovieInfoDTO {
    public string NameRu { get; set; } = "";
    public string? NameEn { get; set; }
    public string? NameOriginal { get; set; }
    MediaType type;
    public string Type { 
        get => Enum.GetName(typeof(MediaType), type)!;
        set => type = Enum.Parse<MediaType>(value);
    }    
    public List<GenreModel> genres { get; set; } = new List<GenreModel>();
    public List<CountryModel> countries { get; set; } = new List<CountryModel>();    
    public int KinopoiskId { get; set; }
    public int Year { get; set; }
    public string Description { get; set; } = "";
    public double Rating { get; set; }
    public string PosterUrl { get; set; } = "";
    public string PosterUrlPreview { get; set; } = "";
}