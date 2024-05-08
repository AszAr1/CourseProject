using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kinopoisk.Models;

[Table("movies_genres")]
public class MovieGenreModel {
    [Column("id")]
    public int Id { get; set; }

    [Column("movie_id")]
    [ForeignKey("MovieId")]
    public int MovieId { get; set; }

    [Column("genre_id")]
    [ForeignKey("GenreId")]
    public int GenreId { get; set; }

    public MovieModel? Movie { get; set; }
    public GenreModel? Genre { get; set; }

}