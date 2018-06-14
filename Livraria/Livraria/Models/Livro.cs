using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Models
{
    public class Livro
    {
        [Key]
        public String Isbn { get; set; }
        [Required]
        public String Titulo { get; set; }
        [Required]
        public String Prefacio { get; set; }
        public  IList<Autor> Autores { get; set; }
        public  IList<Comentario> Comentarios { get; set; }
    }
}
