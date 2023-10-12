using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EncargadoPController : ControllerBase
	{
		private readonly AplicationDbContext _context;

		public EncargadoPController(AplicationDbContext context)
		{
			_context = context;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listEncargados = await _context.encargado.ToListAsync();
				return Ok(listEncargados);
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
				var encargado = await _context.encargado.FindAsync(id);
				if (encargado == null)
				{
					return NotFound();

				}
				return Ok(encargado);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

	}
}
