using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("movie_genres")]
public class MovieGenreModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = "";
}