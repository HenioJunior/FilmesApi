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
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Sessao>()
        .HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });
        
        builder.Entity<Sessao>()
        .HasOne(sessao => sessao.Cinema)
        .WithMany(cinema => cinema.Sessoes)
        .HasForeignKey(sessao => sessao.CinemaId);

        builder.Entity<Sessao>()
        .HasOne(sessao => sessao.Filme)
        .WithMany(filme => filme.Sessoes)
        .HasForeignKey(sessao => sessao.FilmeId);

        builder.Entity<Endereco>()
        .HasOne(endereco => endereco.Cinema)
        .WithOne(cinema => cinema.Endereco)
        .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Filme> Filmes { get; set; }
	
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Endereco> Enderecos { get; set; }

    public DbSet<Sessao> Sessoes { get; set; }
}
