using Newtonsoft.Json;

namespace Kinopoisk.DTOs.MovieInfo;

public class CreateUpdateMovieInfoDTO {
    public string NameRu { get; set; } = "";
    public string? NameEn { get; set; }
    public string NameOriginal { get; set; } = "";
    MediaType type;
    public string Type { 
        get => Enum.GetName(typeof(MediaType), type)!;
        set => type = Enum.Parse<MediaType>(value);
    }    
    int filmId;
    public int FilmId { 
        get {
            return filmId; 
        } 
        set {
            filmId = value;
            KinopoiskId = value;
        } 
    }
    public int KinopoiskId { get; set; }
    public int Year { get; set; }
    public string Description { get; set; } = "";
    public string FilmLength { get; set; } = "";
    public List<Dictionary<string, string>> DictCountries { get; set; } = new List<Dictionary<string, string>>();    
    public List<Dictionary<string, string>> DictGenres { get; set; } = new List<Dictionary<string, string>>();    
    [JsonConverter(typeof(NullToDoubleConverter))]
    public double? RatingKinopoisk { get; set; }
    double? rating;
    [JsonConverter(typeof(NullToDoubleConverter))]
    public double? Rating {
        get {
            return rating;
        } 
        set {
            RatingKinopoisk = value;
            rating = value;
        }
    }
    public string PosterUrl { get; set; } = "";
    public string PosterUrlPreview { get; set; } = "";   
}