using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EncargadoController : ControllerBase
	{
		private readonly AplicationDbContext _context;

		public EncargadoController(AplicationDbContext context)
		{
			_context = context;

		}
		// GET: api/<EncargadoController>
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

		// GET api/<EncargadoController>/5
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

		// POST api/<EncargadoController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Encargado encargado)
		{
			try
			{
				_context.Add(encargado);
				await _context.SaveChangesAsync();
				return Ok(encargado);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// PUT api/<EncargadoController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Encargado encargado)
		{
			try
			{
				if (id != encargado.Id)
				{
					return BadRequest();

				}
				_context.Update(encargado);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Encargado actualizado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<EncargadoController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var encargado = await _context.encargado.FindAsync(id);
				if (encargado == null)
				{
					return NotFound();
				}
				_context.encargado.Remove(encargado);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Encargado eliminado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
