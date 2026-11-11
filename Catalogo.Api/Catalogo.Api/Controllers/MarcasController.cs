using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly CatalogoDbContext _context;

        public MarcasController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            return await _context.Marca.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            if (marca == null) return NotFound(new { Message = "Marca no encontrada" });
            return marca;
        }

        [HttpPost]
        public async Task<ActionResult<Marca>> CrearMarca(Marca marca)
        {
            _context.Marca.Add(marca);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMarca), new { id = marca.IdMarca }, marca);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarMarca(int id, Marca marca)
        {
            if (id != marca.IdMarca) return BadRequest(new { Message = "El ID no coincide" });

            _context.Entry(marca).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarMarca(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            if (marca == null) return NotFound(new { Message = "Marca no encontrada" });

            _context.Marca.Remove(marca);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}