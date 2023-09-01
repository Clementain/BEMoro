using BEMoro.Models;
using Microsoft.EntityFrameworkCore;

namespace BEMoro
{
	public class AplicationDbContext : DbContext
	{
		public DbSet<Noticia> noticia { get; set; }

		public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
		{

		}
	}
}
