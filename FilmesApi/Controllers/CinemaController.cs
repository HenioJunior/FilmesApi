using System;
using AutoMapper;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[Controller]")]
public class CinemaController: ControllerBase
{
	private FilmeContext _context;
	private IMapper _mapper;

	public CinemaController(FilmeContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;

	}

		
}

