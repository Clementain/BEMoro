using BEMoro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class EventoController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public EventoController(AplicationDbContext context)
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

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Evento evento)
		{
			try
			{
				_context.Add(evento);
				await _context.SaveChangesAsync();
				return Ok(evento);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Evento evento)
		{
			try
			{
				if (id != evento.Id)
				{
					return BadRequest();

				}
				_context.Update(evento);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Evento actualizado con exito" });
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
				var evento = await _context.evento.FindAsync(id);
				if (evento == null)
				{
					return NotFound();
				}
				_context.evento.Remove(evento);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Evento eliminado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
