using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;


[Table("movie_infos")]
public class MovieInfoModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("kinopoisk_id")]
    public int FilmId { get; set; }
    [Column("film_id")]
    public string NameRu { get; set; } = "";
    [Column("name_original")]
    public string? NameEn { get; set; }
    [Column("type")]
    public MediaType Type { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("description")]
    public string Description { get; set; } = "";
    [Column("rating_kinopoisk")]
    public double Rating { get; set; }
    [Column("poster_url")]
    public string PosterUrl { get; set; } = "";
    [Column("poster_url_preview")]
    public string PosterUrlPreview { get; set; } = "";
    public MovieModel? Movie { get; set; }
}