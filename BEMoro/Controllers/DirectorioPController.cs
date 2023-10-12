using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DirectorioPController : ControllerBase
	{
		private readonly AplicationDbContext _context;

		public DirectorioPController(AplicationDbContext context)
		{
			_context = context;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listDirectorios = await _context.directorio.ToListAsync();
				return Ok(listDirectorios);
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
				var directorio = await _context.directorio.FindAsync(id);
				if (directorio == null)
				{
					return NotFound();

				}
				return Ok(directorio);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
