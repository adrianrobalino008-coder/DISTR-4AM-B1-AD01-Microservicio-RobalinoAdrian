using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CatalogoDbContext _context;

        public CategoriasController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categoria.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null) return NotFound(new { Message = "Categoría no encontrada" });
            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> CrearCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarCategoria(int id, Categoria categoria)
        {
            if (id != categoria.IdCategoria) return BadRequest(new { Message = "El ID no coincide" });

            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null) return NotFound(new { Message = "Categoría no encontrada" });

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}