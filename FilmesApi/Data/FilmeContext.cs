using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

#pragma warning disable CS1591
#pragma warning disable CS8618

namespace FilmesApi.Data;

	public class FilmeContext: DbContext
	{
		public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
		{
		}

    public DbSet<Filme> Filmes { get; set; }
	
	public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Sessao> Sessoes { get; set; }
	}

