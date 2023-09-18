using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

#pragma warning disable CS1591

namespace FilmesApi.Profiles
{
	public class FilmeProfile : Profile
	{
		public FilmeProfile()
		{
			CreateMap<CreateFilmeDto, Filme>();
			CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
			CreateMap<Filme, ReadFilmeDto>();
        }
	}
}

