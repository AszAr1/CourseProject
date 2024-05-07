using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("movies")]
public class MovieModel {
    private string BASE_PATH = @"..\assets\movies\";
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