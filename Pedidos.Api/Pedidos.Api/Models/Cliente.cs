using System.ComponentModel.DataAnnotations;

namespace Pedidos.Api.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
    }
}