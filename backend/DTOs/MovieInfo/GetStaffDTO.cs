namespace Kinopoisk.DTOs.MovieInfo;

public class GetStaffDTO {
    public int StaffId { get; set; }
    public string  NameRu { get; set; } = "";
    public string NameEn { get; set; } = "";
    public string? Description { get; set; }
    public string PosterUrl { get; set; } = "";
    public string ProfessionText { get; set; } = "";
    public StaffProffesion ProfessionKey { get; set; }

    public override string ToString() {
        return $"Staff id: {StaffId}\nNameRu: {NameEn}\nNameEn: {NameEn}\nDescription: {Description}\nProfession: {ProfessionKey}";
    }
}