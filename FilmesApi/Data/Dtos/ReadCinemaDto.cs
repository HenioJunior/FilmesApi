#pragma warning disable CS1591

namespace FilmesApi.Data.Dtos;

public class ReadCinemaDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public ReadEnderecoDto? EnderecoDto { get; set; }
}

