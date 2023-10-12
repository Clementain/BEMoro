using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoticiaPController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public NoticiaPController(AplicationDbContext context)
		{
			_context = context;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listNoticias = await _context.noticia.ToListAsync();
				return Ok(listNoticias);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var noticia = await _context.noticia.FindAsync(id);
				if (noticia == null)
				{
					return NotFound();
				}
				return Ok(noticia);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
