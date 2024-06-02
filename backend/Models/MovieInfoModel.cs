using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;


[Table("movie_infos")]
public class MovieInfoModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("kinopoisk_id")]
    public int KinopoiskId { get; set; }

    [Column("name_ru")]
    public string? NameRu { get; set; }
    
    [Column("name_en")]
    public string? NameEn { get; set; }

    [Column("name_original")]
    public string? NameOriginal { get; set; }

    MediaType type;
    [Column("type")]
    public string Type { 
        get => Enum.GetName(typeof(MediaType), type)!;
        set => type = Enum.Parse<MediaType>(value);
    }    
    
    [Column("year")]
    public int Year { get; set; }
    
    [Column("description")]
    public string? Description { get; set; }
        
    [Column("rating_kinopoisk")]
    public double? RatingKinopoisk { get; set; }
    
    [Column("poster_url")]
    public string PosterUrl { get; set; } = "";
    
    [Column("poster_url_preview")]
    public string PosterUrlPreview { get; set; } = "";

    public MovieModel? Movie { get; set;}
    public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
    public List<CountryModel> Countries { get; set; } = new List<CountryModel>();

    public override string ToString() {
        return $"Name: {NameEn}, Year: {Year}, Rating on Kinopoisk: {RatingKinopoisk}";
    }
}