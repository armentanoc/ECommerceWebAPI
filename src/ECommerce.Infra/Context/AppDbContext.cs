
using ECommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<Refund> Refund { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
        public DbSet<ProductSale> ProductSale { get; set; }
        public DbSet<ProductExchange> ProductExchange { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Refund>().HasKey(r => r.Id);
            modelBuilder.Entity<Sale>().HasKey(s => s.Id);
            modelBuilder.Entity<Exchange>().HasKey(e => e.Id);
            modelBuilder.Entity<ProductSale>().HasKey(e => e.Id);
            modelBuilder.Entity<ProductExchange>().HasKey(e => e.Id);

            //modelBuilder.Entity<ProductSale>()
            //    .HasOne(ps => ps.Sale)
            //    .WithMany(s => s.SaleProducts);

            //modelBuilder.Entity<ProductExchange>()
            //    .HasOne(pe => pe.Exchange)
            //    .WithMany(e => e.ProductExchanges);

        }
    }
}
