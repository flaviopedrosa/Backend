using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Autor
    {
        public Autor()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public IList<Livro> Livros { get; set; }
        public  IList<CarrinhoCompra> CarrinhosCompras { get; set; }
    }
}