namespace Kinopoisk.DTOs.Movie;

public class CreateMovieDTO {
    public IFormFile? File { get; set; }
    public string Name { get; set; }  = "";
}