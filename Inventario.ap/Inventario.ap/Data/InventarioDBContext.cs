using Microsoft.EntityFrameworkCore;
using Inventario.ap.Models;

namespace Inventario.ap.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
        {
        }

        public DbSet<Bodega> Bodega { get; set; }
        public DbSet<Existencia> Existencia { get; set; }
        public DbSet<MovimientoInventario> MovimientoInventario { get; set; }
        public DbSet<ReservaStock> ReservaStock { get; set; }
    }
}