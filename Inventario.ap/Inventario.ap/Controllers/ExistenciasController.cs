using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventario.ap.Data;
using Inventario.ap.Models;

namespace Inventario.ap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExistenciasController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ExistenciasController(InventarioDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistencias()
        {
            return await _context.Existencia.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Existencia>> GetExistencia(int id)
        {
            var existencia = await _context.Existencia.FindAsync(id);
            if (existencia == null)
            {
                return NotFound(new { Message = "Existencia no encontrada" });
            }
            return existencia;
        }

        [HttpGet("por-producto/{idProducto:int}")]
        public async Task<ActionResult<IEnumerable<Existencia>>> GetExistenciasPorProducto(int idProducto)
        {
            var existencias = await _context.Existencia
                .Where(e => e.IdProducto == idProducto)
                .AsNoTracking()
                .ToListAsync();

            if (!existencias.Any())
            {
                return NotFound(new { Message = "No hay existencias registradas para este producto" });
            }

            return existencias;
        }

        [HttpPost]
        public async Task<ActionResult<Existencia>> CrearExistencia(Existencia existencia)
        {
            _context.Existencia.Add(existencia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExistencia), new { id = existencia.IdExistencia }, existencia);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarExistencia(int id, Existencia existencia)
        {
            if (id != existencia.IdExistencia)
            {
                return BadRequest(new { Message = "El ID de la existencia no coincide" });
            }

            _context.Entry(existencia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarExistencia(int id)
        {
            var existencia = await _context.Existencia.FindAsync(id);
            if (existencia == null)
            {
                return NotFound(new { Message = "Existencia no encontrada" });
            }

            _context.Existencia.Remove(existencia);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}