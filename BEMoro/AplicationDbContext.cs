using BEMoro.Models;
using Microsoft.EntityFrameworkCore;

namespace BEMoro
{
	public class AplicationDbContext : DbContext
	{
		public DbSet<Noticia> noticia { get; set; }
		public DbSet<Documento> documento { get; set; }
		public DbSet<Encargado> encargado { get; set; }
		public DbSet<ProgramaSocial> programaSocial { get; set; }
		public DbSet<Vecs> vecs { get; set; }
		public DbSet<Directorio> directorio { get; set; }
		public DbSet<Evento> evento { get; set; }
		public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
		{

		}
	}
}
