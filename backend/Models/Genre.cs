using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("genres")]
public class GenreModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = "";
}