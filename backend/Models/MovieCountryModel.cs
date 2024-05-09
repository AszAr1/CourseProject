using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kinopoisk.Models;

[Table("movies_countries")]
public class MovieCountryModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("movie_info_id")]
    [ForeignKey("MovieInfoId")]
    public Guid MovieInfoId { get; set; }

    [Column("country_id")]
    [ForeignKey("CountryId")]
    public Guid CountryId { get; set; }
    
    public MovieInfoModel? MovieInfo { get; set; }
    public CountryModel? Country { get; set; }
}