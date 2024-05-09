using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("genres")]
public class GenreModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column("name")]
    public string Name { get; set; } = "";
}