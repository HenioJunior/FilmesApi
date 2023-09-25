using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

#pragma warning disable CS1591

namespace FilmesApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
        CreateMap<UpdateEnderecoDto, Endereco>();
    }
}
