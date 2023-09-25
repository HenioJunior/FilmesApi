using System.ComponentModel.DataAnnotations;
using FilmesApi.Models;

#pragma warning disable CS1591
#pragma warning disable CS8618

namespace FilmesApi.Models;
public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int Numero { get; set; }
    public virtual Cinema Cinema { get; set; }
}
