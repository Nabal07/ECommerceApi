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
            
            modelBuilder.Entity<Produto>().HasData(
                new Produto("Memoria RAM", "16gb", 789){Id = Guid.Parse("71ca286f-f19b-4be1-b67c-01345d96763b") },
                new Produto("Placa de Video", "RX580", 700){ Id = Guid.Parse("788a47aa-e189-4620-9e03-538502aa8814")});

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario("Maria", []) { Id = Guid.Parse("c74fd54f-cd3b-49d1-929f-98e7eedddda4") },
                new Usuario("Joao", []) { Id = Guid.Parse("1ba005be-e8f9-42dc-96c5-5bca0b5e1712") });

        }



    }
}