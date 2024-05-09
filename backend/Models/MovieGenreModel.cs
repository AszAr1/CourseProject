using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kinopoisk.Models;

[Table("movies_genres")]
public class MovieGenreModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("movie_info_id")]
    [ForeignKey("MovieInfoId")]
    public Guid MovieInfoId { get; set; }

    [Column("genre_id")]
    [ForeignKey("GenreId")]
    public Guid GenreId { get; set; }

    public MovieInfoModel? MovieInfo { get; set; }
    public GenreModel? Genre { get; set; }

}