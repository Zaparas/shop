using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.Extensions.Options;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PurchaseProduct>()
                .HasKey(pp => new { pp.PurchaseId, pp.ProductId });  // Composite key

            modelBuilder.Entity<PurchaseProduct>()
                .HasOne<Purchase>()
                .WithMany()
                .HasForeignKey(pp => pp.PurchaseId);

            modelBuilder.Entity<PurchaseProduct>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(pp => pp.ProductId);
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
    }
}