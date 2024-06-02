using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kinopoisk.Models;

[Keyless]
[Table("movies_genres")]
public class MovieGenreModel {
    [Column("movie_info_id")]
    [ForeignKey(nameof(MovieInfo))]
    public Guid MovieInfoId { get; set; }

    [Column("genre_id")]
    [ForeignKey(nameof(Genre))]
    public Guid GenreId { get; set; }

    public MovieInfoModel? MovieInfo { get; set; }
    public GenreModel? Genre { get; set; }

}