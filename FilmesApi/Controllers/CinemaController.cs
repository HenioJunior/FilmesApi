using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS1591

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
	private FilmeContext _context;

    private IMapper _mapper;

	public CinemaController(FilmeContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

  	[HttpPost]
    public IActionResult AdicionarCinema([FromBody] CreateCinemaDto cinemaDto)
	{
		Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
		_context.Cinemas.Add(cinema);
		_context.SaveChanges();
		return CreatedAtAction(nameof(RecuperarCinemaPorId), new { Id = cinema.Id }, cinemaDto);
	}

	[HttpGet]
	public IEnumerable<ReadCinemaDto> RecuperaCinemas()
	{
		return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
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


