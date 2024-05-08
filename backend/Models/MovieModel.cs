using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("movies")]
public class MovieModel {
    public static readonly string BASE_PATH = @".\assets\movies";
    public static readonly string BASE_URI = "http://localhost:5054/movies/get?path=";
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = "";
    [Column("uri")]
    public string Uri { get; set; } = "";
    [Column("movie_info_id")]
    [ForeignKey("MovieInfoId")]
    public int MovieInfoId { get; set; }
    public MovieInfoModel? MovieInfo { get; set; }
}