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
    public class VecsController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public VecsController(AplicationDbContext context)
        {
            _context = context;

        }
        // GET: api/<VecsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listVecs = await _context.vecs.ToListAsync();
                return Ok(listVecs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<VecsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var vecs = await _context.vecs.FindAsync(id);
                if (vecs == null)
                {
                    return NotFound();
                }
                return Ok(vecs);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST api/<NoticiasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vecs vecs)
        {
            try
            {
                _context.Add(vecs);
                await _context.SaveChangesAsync();
                return Ok(vecs);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/<NoticiasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Vecs vecs)
        {
            try
            {
                if (id != vecs.Id)
                {
                    return BadRequest();

                }
                _context.Update(vecs);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Documento actualizada con exito" });
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
                var vecs = await _context.vecs.FindAsync(id);
                if (vecs == null)
                {
                    return NotFound();
                }
                _context.vecs.Remove(vecs);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Documento eliminado con exito" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
