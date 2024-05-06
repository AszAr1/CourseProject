using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("countries")]
public class CountryModel {
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; } = "";
}