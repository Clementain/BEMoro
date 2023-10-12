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
	public class DocumentoController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public DocumentoController(AplicationDbContext context)
		{
			_context = context;

		}
		// GET: api/<DocumentoController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			try
			{
				var listDocumentos = await _context.documento.ToListAsync();
				return Ok(listDocumentos);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// GET api/<DocumentoController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				var documento = await _context.documento.FindAsync(id);
				if (documento == null)
				{
					return NotFound();
				}
				return Ok(documento);


			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// POST api/<DocumentoController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Documento documento)
		{
			try
			{
				_context.Add(documento);
				await _context.SaveChangesAsync();
				return Ok(documento);
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// PUT api/<DocumentoController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Documento documento)
		{
			try
			{
				if (id != documento.Id)
				{
					return BadRequest();

				}
				_context.Update(documento);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Documento actualizado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		// DELETE api/<DocumentoController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				var documento = await _context.documento.FindAsync(id);
				if (documento == null)
				{
					return NotFound();
				}
				_context.documento.Remove(documento);
				await _context.SaveChangesAsync();
				return Ok(new { message = "Documento eliminado con exito" });
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetDocumentosByEncargadoId")]
		public async Task<IActionResult> GetDocumentosByEncargadoId(int encargadoId)
		{
			try
			{
				var documentos = await _context.documento
					.FromSqlRaw("CALL GetDocumentosByEncargadoId({0})", encargadoId)
					.ToListAsync();

				return Ok(documentos);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
