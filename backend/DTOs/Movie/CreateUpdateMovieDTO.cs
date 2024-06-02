namespace Kinopoisk.DTOs.Movie;

public class CreateUpdateMovieDTO {
    public IFormFile? File { get; set; }
    public string? Name { get; set; }
}