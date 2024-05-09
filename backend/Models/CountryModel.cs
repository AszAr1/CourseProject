using System.ComponentModel.DataAnnotations.Schema;

namespace Kinopoisk.Models;

[Table("countries")]
public class CountryModel {
    [Column("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Column("name")]
    public string Name { get; set; } = "";
}