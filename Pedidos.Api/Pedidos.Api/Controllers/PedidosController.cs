using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Data;
using Pedidos.Api.Models;

namespace Pedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidosDbContext _context;

        public PedidosController(PedidosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedido.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound(new { Message = "Pedido no encontrado" });
            }
            return pedido;
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> CrearPedido(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedido);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> ActualizarPedido(int id, Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return BadRequest(new { Message = "El ID del pedido no coincide" });
            }

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> EliminarPedido(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound(new { Message = "Pedido no encontrado" });
            }

            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}