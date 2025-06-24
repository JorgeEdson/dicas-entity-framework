using Microsoft.EntityFrameworkCore;
using warehouse.Dominio.Entidades;

namespace warehouse.Infraestrutura.Contextos
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Almoxarifado> Almoxarifados { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EstoqueItem> EstoqueItems { get; set; }

        public WarehouseContext(DbContextOptions<WarehouseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais, se necessário (ex: chaves compostas, índices)
            modelBuilder.Entity<EstoqueItem>()
                .HasOne(ei => ei.Produto)
                .WithMany()
                .HasForeignKey(ei => ei.IdProduto);

            modelBuilder.Entity<EstoqueItem>()
                .HasOne(ei => ei.Almoxarifado)
                .WithMany(a => a.EstoqueItems)
                .HasForeignKey(ei => ei.IdAlmoxarifado);

            // Exemplo de índice para performance
            modelBuilder.Entity<EstoqueItem>()
                .HasIndex(ei => ei.IdProduto);
            modelBuilder.Entity<EstoqueItem>()
                .HasIndex(ei => ei.IdAlmoxarifado);
        }
    }
}
