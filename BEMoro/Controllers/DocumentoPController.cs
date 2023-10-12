using BEMoro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BEMoro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DocumentoPController : ControllerBase
	{
		private readonly AplicationDbContext _context;
		public DocumentoPController(AplicationDbContext context)
		{
			_context = context;

		}
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
