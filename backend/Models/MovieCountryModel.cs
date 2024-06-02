using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kinopoisk.Models;

[Keyless]
[Table("movies_countries")]
public class MovieCountryModel {
    [Column("movie_info_id")]
    [ForeignKey(nameof(MovieInfo))]
    public Guid MovieInfoId { get; set; }

    [Column("country_id")]
    [ForeignKey(nameof(Country))]
    public Guid CountryId { get; set; }
    
    public MovieInfoModel? MovieInfo { get; set; }
    public CountryModel? Country { get; set; }
}