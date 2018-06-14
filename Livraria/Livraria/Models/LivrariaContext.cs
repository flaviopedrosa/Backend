using Microsoft.EntityFrameworkCore;

namespace Livraria.Models
{
    public class LivrariaContext : DbContext
    {

        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
        {
            if (this.Database.EnsureCreated())
            {
               // log.Info("Database created successfully.");
            }
            else
            {
                this.Database.Migrate();

                //log.Info("Database migrated successfully.");
            }
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<CarrinhoCompra> CarrinhosCompras { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
