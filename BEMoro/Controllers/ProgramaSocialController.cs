using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProgramaSocialController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public ProgramaSocialController(AplicationDbContext context)
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

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ProgramaSocial ps)
		{
			try
			{
				_context.Add(ps);
				await _context.SaveChangesAsync();
				return Ok(ps);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] ProgramaSocial ps)
		{
			try
			{
				if (id != ps.Id)
				{
					return BadRequest();

				}
				_context.Update(ps);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Programa social actualizada con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var ps = await _context.programaSocial.FindAsync(id);
				if (ps == null)
				{
					return NotFound();
				}
				_context.programaSocial.Remove(ps);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Programa social eliminada con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
