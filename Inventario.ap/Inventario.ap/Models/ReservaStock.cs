using System.ComponentModel.DataAnnotations;

namespace Inventario.ap.Models
{
    public class ReservaStock
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdProducto { get; set; } 
        public int IdBodega { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; } = string.Empty; 
    }
}