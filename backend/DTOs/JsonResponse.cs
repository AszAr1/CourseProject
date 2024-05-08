namespace  Kinopoisk.Models;

public class JsonResponse {
    public string Keyword { get; set; } = "";
    public int PagesCount { get; set; } = 0;
    public List<CreateMovieInfoDTO> Films { get; set; } = new List<CreateMovieInfoDTO>();
    public int SearchFilmsCountResult { get; set; }
    
}