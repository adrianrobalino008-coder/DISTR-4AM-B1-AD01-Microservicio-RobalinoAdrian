using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalogo.Api.Data;
using Catalogo.Api.Models;

namespace Catalogo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly CatalogoDbContext _context;

        public ProductosController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            var productos = await _context.Producto
                .AsNoTracking()
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound(new { Message = "Producto no encontrado" });
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> CrearProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducto), new { id = producto.IdProducto }, producto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarProducto(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest(new { Message = "El ID del producto no coincide" });
            }

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { Message = "Producto no encontrado" });
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("cambiar-estado/{id:int}")]
        public async Task<ActionResult> CambiarEstadoProducto(int id, bool estado)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound(new { Message = "Producto no encontrado" });
            }

            producto.Estado = estado;
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}