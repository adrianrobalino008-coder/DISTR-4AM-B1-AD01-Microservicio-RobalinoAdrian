using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.ap.Data;
using Inventario.ap.Models;

namespace Inventario.ap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodegasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public BodegasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bodega>>> GetBodegas()
        {
            return await _context.Bodega.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Bodega>> GetBodega(int id)
        {
            var bodega = await _context.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound(new { Message = "Bodega no encontrada" });
            }
            return bodega;
        }

        [HttpPost]
        public async Task<ActionResult<Bodega>> CrearBodega(Bodega bodega)
        {
            _context.Bodega.Add(bodega);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBodega), new { id = bodega.IdBodega }, bodega);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarBodega(int id, Bodega bodega)
        {
            if (id != bodega.IdBodega)
            {
                return BadRequest(new { Message = "El ID de la bodega no coincide" });
            }

            _context.Entry(bodega).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarBodega(int id)
        {
            var bodega = await _context.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound(new { Message = "Bodega no encontrada" });
            }

            _context.Bodega.Remove(bodega);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}