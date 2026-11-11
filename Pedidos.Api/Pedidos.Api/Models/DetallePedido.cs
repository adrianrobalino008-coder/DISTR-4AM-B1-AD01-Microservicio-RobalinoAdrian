using System.ComponentModel.DataAnnotations;

namespace Pedidos.Api.Models
{
    public class DetallePedido
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}