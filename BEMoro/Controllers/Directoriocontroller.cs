using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Directoriocontroller : ControllerBase
	{
		private readonly AplicationDbContext _context;

		public Directoriocontroller(AplicationDbContext context)
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

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Directorio directorio)
		{
			try
			{
				_context.Add(directorio);
				await _context.SaveChangesAsync();
				return Ok(directorio);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Directorio directorio)
		{
			try
			{
				if (id != directorio.Id)
				{
					return BadRequest();

				}
				_context.Update(directorio);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Directorio actualizado con exito" });
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
				var directorio = await _context.directorio.FindAsync(id);
				if (directorio == null)
				{
					return NotFound();
				}
				_context.directorio.Remove(directorio);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Directorio eliminado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
