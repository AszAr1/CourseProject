namespace Kinopoisk.DTOs.User;

public class GetUserDTO {
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public bool IsAuthorized { get; set; }
}