using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591
#pragma warning disable CS8618

namespace FilmesApi.Models;

public class Cinema
{

    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório!")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
    public virtual Endereco Endereco { get; set; }
}

