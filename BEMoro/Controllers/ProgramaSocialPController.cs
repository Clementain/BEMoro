using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProgramaSocialPController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public ProgramaSocialPController(AplicationDbContext context)
		{
			_context = context;

		}
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listPS = await _context.programaSocial.ToListAsync();
				return Ok(listPS);
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
				var ps = await _context.programaSocial.FindAsync(id);
				if (ps == null)
				{
					return NotFound();
				}
				return Ok(ps);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
