using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventoPController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public EventoPController(AplicationDbContext context)
		{
			_context = context;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listEventos = await _context.evento.ToListAsync();
				return Ok(listEventos);
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
				var evento = await _context.evento.FindAsync(id);
				if (evento == null)
				{
					return NotFound();
				}
				return Ok(evento);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
