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
	public class NoticiaController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public NoticiaController(AplicationDbContext context)
		{
			_context = context;

		}
		// GET: api/<NoticiasController>
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

		// GET api/<NoticiasController>/5
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

		// POST api/<NoticiasController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Noticia noticia)
		{
			try
			{
				_context.Add(noticia);
				await _context.SaveChangesAsync();
				return Ok(noticia);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// PUT api/<NoticiasController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Noticia noticia)
		{
			try
			{
				if (id != noticia.Id)
				{
					return BadRequest();

				}
				_context.Update(noticia);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Noticia actualizada con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<NoticiasController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var noticia = await _context.noticia.FindAsync(id);
				if (noticia == null)
				{
					return NotFound();
				}
				_context.noticia.Remove(noticia);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Noticia eliminada con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}
	}
}
