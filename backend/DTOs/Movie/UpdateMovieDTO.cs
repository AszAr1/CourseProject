namespace Kinopoisk.DTOs.Movie;

public class UpdateMovieDTO {
    public IFormFile? File { get; set; }
    public string Name { get; set; }  = "";
}