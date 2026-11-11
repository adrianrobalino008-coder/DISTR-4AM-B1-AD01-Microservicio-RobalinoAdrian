using Microsoft.EntityFrameworkCore;
using Pedidos.Api.Models;

namespace Pedidos.Api.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
    }
}