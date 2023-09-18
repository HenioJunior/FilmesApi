using System;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;


[ApiController]
[Route("[Controller]")]
public class CinemaController : ControllerBase
{
	private FilmeContext _context;

    private IMapper _mapper;

	public CinemaController(FilmeContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

    /// <summary>
    /// Adiciona um cinema ao banco de dados
    /// </summary>
    /// <param name="cinemaDto">Objeto com os campos necessários para criação de um cinema</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
	[HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
	{
		var cinema = _mapper.Map<Cinema>(cinemaDto);
		_context.Cinemas.Add(cinema);
		_context.SaveChanges();
		return CreatedAtAction(nameof(RecuperarCinemaPorId), new { id = cinema.Id }, cinema);
	}

	[HttpGet]
	public IEnumerable<ReadCinemaDto> RecuperaCinemas([FromQuery] int skip=0, int take = 5)
	{
		return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take));
	}

	[HttpGet("{id}")]
	public IActionResult RecuperarCinemaPorId(int id)
	{
		var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
		if (cinema == null) return NotFound();
		var cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
		return Ok(cinemaDto);
	}

	[HttpPut("{id}")]
	public IActionResult AtualizarCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
	{
        var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        if (cinema == null) return NotFound();
		_mapper.Map(cinemaDto, cinema);
		_context.SaveChanges();
		return NoContent();
	}

    [HttpPatch("{id}")]
    public IActionResult AtualizarCinemaParcial(int id,
        JsonPatchDocument<UpdateCinemaDto> patch)
    {
        var cinema = _context.Cinemas.FirstOrDefault(
            cinema => cinema.Id == id);
        if (cinema == null) return NotFound();

        var cinemaParaAtualizar = _mapper.Map<UpdateCinemaDto>(cinema);

        patch.ApplyTo(cinemaParaAtualizar, ModelState);

        if (!TryValidateModel(cinemaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(cinemaParaAtualizar, cinema);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(cinema =>
        cinema.Id == id);
        if (cinema == null) return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
       
}


