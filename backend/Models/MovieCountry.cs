using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("movies_countries")]
public class MovieCountryModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("movie_id")]
    [ForeignKey("MovieId")]
    public int MovieId { get; set; }
    [Column("country_id")]
    [ForeignKey("CountryId")]
    public int CountryId { get; set; }
    public MovieModel? Movie { get; set; }
    public CountryModel? Country { get; set; }
}