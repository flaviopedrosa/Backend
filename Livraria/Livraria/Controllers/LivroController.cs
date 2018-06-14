using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.Controllers
{
    /// <summary>
    /// Recurso para operações de livro
    /// </summary>
    [Route("public/v1/[controller]")]
    public class LivroController : Controller
    {
        private readonly LivrariaContext _context;

        public LivroController(LivrariaContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        /// <summary>
        /// Recupera uma lista de livros existentes no sistema.
        /// </summary>
        /// <param name="isbn">ISBN do Livro</param>
        /// <param name="titulo">Título ou parte do título do livro</param>
        /// <param name="offset">Indica um salto na lista</param>
        /// <param name="quantidade">Indica a quantidade máxima de registros, sendo limitado a 100. Valor default 20. </param>
        /// <returns>Lista de Livros</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(502)]
        [ProducesResponseType(504)]
        public ActionResult<IList<Livro>> Get(string isbn = null, string titulo = null, string nomeAutor = null, int offset = 0, int quantidade = 20)
        {
            try
            {
                var listaDeLivros = Mock.Livros.Where(x =>
                                                (x.Isbn == isbn || isbn == null)
                                                && (x.Titulo.Contains(titulo) || titulo == null)
                                                ).Skip(offset)
                                                .Take(quantidade)
                                                .ToList();
                if (listaDeLivros == null)
                    return NoContent();
                else
                    return Ok(listaDeLivros);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Recupera detalhes de um livro em especifico informado atraves do isbn.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        [HttpGet("{isbn}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(502)]
        [ProducesResponseType(504)]
        public ActionResult<Livro> Get(string isbn)
        {
            try
            {
                Livro livro = Mock.Livros.Where(x => x.Isbn == isbn).FirstOrDefault();
                if (livro == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(livro);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        /// <summary>
        /// Cria um novo registro refernte à livro.
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]Livro model)
        {
            try
            {
                Mock.Livros.Add(model);

                return StatusCode(201);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Altera um livro previamente existente na base de dados.
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpPut("{isbn}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Put(string isbn, [FromBody]Livro model)
        {
            try
            {
                Mock.Livros.Remove(Mock.Livros.Where(x => x.Isbn == isbn).FirstOrDefault());
                Mock.Livros.Add(model);
                
                return StatusCode(200);
                
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Exclui um livro previamente existente na base de dados.
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpDelete("{isbn}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Delete(string isbn)
        {
            try
            {
                Mock.Livros.Remove(Mock.Livros.Where(x => x.Isbn == isbn).FirstOrDefault());
               

                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
