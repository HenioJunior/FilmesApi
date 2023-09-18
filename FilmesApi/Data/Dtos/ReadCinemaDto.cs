#pragma warning disable CS1591
#pragma warning disable CS8618

namespace FilmesApi.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ReadEnderecoDto Endereco { get; set; }
}

