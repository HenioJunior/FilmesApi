using System.ComponentModel.DataAnnotations;

#pragma warning disable CS1591
#pragma warning disable CS8618

namespace FilmesApi.Data.Dtos;
public class UpdateCinemaDto
{
	[Required(ErrorMessage = "O campo de nome é obrigatório!")]
	public string Nome { get; set; }
}

