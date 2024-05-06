using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kinopoisk.Models;


[Table("movie_infos")]
public class MovieInfoModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("kinopoisk_id")]
    public int KinopoiskId { get; set; }
    [Column("imdb_id")]
    public int? ImdbId { get; set; }
    [Column("name_ru")]
    public string NameRu { get; set; } = "";
    [Column("name_original")]
    public string? NameOriginal { get; set; }
    [Column("countries")]
    public double RatingKinopoisk { get; set; }
    [Column("rating_imdb")]
    public double RatingImdb { get; set; }
    [Column("year")]
    public int Year { get; set; }
    [Column("type")]
    public MediaType Type { get; set; }
    [Column("poster_url")]
    public string PosterUrl { get; set; } = "";
    [Column("poster_url_preview")]
    public string PosterUrlPreview { get; set; } = "";
    public MovieModel? Movie { get; set; }

}