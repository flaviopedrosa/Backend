using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Models
{
    public static class Mock
    {
        public static IList<Autor> Autores = new List<Autor>
        {
            new Autor{Nome = "João Paulo" },
            new Autor{Nome = "Dirceu Lopes" },
            new Autor{Nome = "Fábio Júnior" },
            new Autor{Nome = "Juninho Bill "}
        };

        public static IList<Livro> Livros = new List<Livro>
        {
            new Livro { Isbn="125625616256256",
                        Autores = Autores,
                        Prefacio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pretium sem aliquet magna faucibus lacinia.",
                        Titulo ="Sobradinho dos pardais"
            },
            new Livro { Isbn="125676565445343",
                        Autores = Autores,
                        Prefacio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pretium sem aliquet magna faucibus lacinia.",
                        Titulo ="Guerra dos tronos"
            },
            new Livro { Isbn="676757655465466",
                        Autores = Autores,
                        Prefacio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pretium sem aliquet magna faucibus lacinia.",
                        Titulo = "Codigo da Vinci"

            },
            new Livro { Isbn="676759889879878",
                        Autores = Autores,
                        Prefacio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse pretium sem aliquet magna faucibus lacinia.",
                        Titulo ="João e o pe de feijão",
            }

        };
    }
}
