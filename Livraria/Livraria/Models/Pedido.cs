using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Pedido : CarrinhoCompra
    {
        [Required]
        public DateTime DataRetirada { get; set; }
        [Required]
        public String Status { get; set; }
    }
}
