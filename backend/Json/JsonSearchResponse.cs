namespace  Kinopoisk.Json;

public class JsonSearchResponse {
    public string Keyword { get; set; } = "";
    public int PagesCount { get; set; } = 0;
    public List<CreateUpdateMovieInfoDTO> Films { get; set; } = new List<CreateUpdateMovieInfoDTO>();
    public int SearchFilmsCountResult { get; set; }
}