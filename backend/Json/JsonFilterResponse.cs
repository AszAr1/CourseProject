namespace Kinopoisk.Json;

public class JsonFilterResponse {
    public int Total { get; set; }
    public int TotalPages { get; set; }
    public List<CreateUpdateMovieInfoDTO> Items { get; set; } = new List<CreateUpdateMovieInfoDTO>();
}