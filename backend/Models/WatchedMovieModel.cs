using System.ComponentModel.DataAnnotations.Schema;

[Table("watched_movies")]
public class WatchedMovieModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Column("movie_id")]
    public Guid MovieId { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [Column("time_stamp")]
    public int TimeStamp { get; set; }

    public UserModel? User { get; set; }
    public MovieModel? Movie { get; set; }     
}