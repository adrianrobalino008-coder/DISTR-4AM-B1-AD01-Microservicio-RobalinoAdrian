using System.ComponentModel.DataAnnotations;

namespace Inventario.ap.Models
{
    public class Bodega
    {
        [Key]
        public int IdBodega { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
    }
}