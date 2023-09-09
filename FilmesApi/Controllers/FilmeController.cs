﻿using System;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController: ControllerBase
{
	private static List<Filme> filmes = new List<Filme>();
	private static int id = 0;

	[HttpPost]
	public IActionResult AdicionarFilme([FromBody] Filme filme)
    {
		filme.Id = id++;
		filmes.Add(filme);
		return CreatedAtAction(nameof(RecuperarFilmePorId), new { id = filme.Id }, filme);
	}

    [HttpGet]
	public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 1, [FromQuery]int take = 0)
	{
		return filmes.Skip(skip).Take(take);
	}

	[HttpGet("{id}")]
	public IActionResult RecuperarFilmePorId(int id)
	{
		var filme = filmes.FirstOrDefault(filme => filme.Id == id);
		if (filme == null) return NotFound();
		return Ok(filme);
    }
}

