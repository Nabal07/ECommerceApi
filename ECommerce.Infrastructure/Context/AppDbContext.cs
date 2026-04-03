using Microsoft.EntityFrameworkCore;
using ECommerce.Domain.Entities;

namespace ECommerce.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
            modelBuilder.Entity<Usuario>().HasKey(c => c.Id);

            modelBuilder.Entity<PedidoItem>().HasOne(a => a.Pedido).WithMany(b => b.Itens).HasForeignKey(a => a.PedidoId);
            modelBuilder.Entity<Pedido>().HasOne(a => a.Comprador).WithMany(b => b.Pedidos).HasForeignKey(a => a.CompradorId);



            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnType("decimal(18,2)");
        }
    }
}