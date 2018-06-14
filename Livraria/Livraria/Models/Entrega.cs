using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Entrega : Pedido
    {
        [Required]
        public DateTime DataEntrega { get; set; }
    }
}
