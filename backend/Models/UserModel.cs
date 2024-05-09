using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("users")]
public class UserModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column("username")]
    public string Username { get; set; } = "";
    [Column("password_digest")]
    public string Password { get; set; } = "";
    [Column("is_admin")]
    public bool IsAdmin { get; set; }
    [Column("is_authorized")]
    public bool IsAuthorized { get; set; }
}