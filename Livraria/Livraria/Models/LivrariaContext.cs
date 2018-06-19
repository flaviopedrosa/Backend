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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>()
                .HasKey(x => x.Isbn);
                
            modelBuilder.Entity<Autor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Comentario>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<CarrinhoCompra>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Pedido>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Entrega>()
                .HasKey(x => x.Id);
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<CarrinhoCompra> CarrinhosCompras { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Entrega> Entregas { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

    }
}
