using System.ComponentModel.DataAnnotations;

namespace Inventario.ap.Models
{
    public class Existencia
    {
        [Key]
        public int IdExistencia { get; set; }
        public int IdProducto { get; set; } 
        public int IdBodega { get; set; }
        public int Stock { get; set; }
    }
}