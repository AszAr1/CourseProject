using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;


[Table("movie_infos")]
public class MovieInfoModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("name_ru")]
    public string NameRu { get; set; } = "";
    
    [Column("name_en")]
    public string? NameEn { get; set; }
    
    [Column("type")]
    public MediaType Type { get; set; }
    
    [Column("year")]
    public int Year { get; set; }
    
    [Column("description")]
    public string Description { get; set; } = "";
    
    [Column("rating")]
    public double Rating { get; set; }
    
    [Column("poster_url")]
    public string PosterUrl { get; set; } = "";
    
    [Column("poster_url_preview")]
    public string PosterUrlPreview { get; set; } = "";
    public MovieModel? Movie { get; set;}
}