using Microsoft.EntityFrameworkCore;
using OrderManagementApp.Models;

namespace OrderManagementApp.Models
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed 15 Products để lấy điểm
            for (int i = 1; i <= 15; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product
                {
                    Id = i,
                    Name = $"Product {i}",
                    Sku = $"SKU{i:000}",
                    Price = i * 10,
                    StockQuantity = 100,
                    Category = "General"
                });
            }
        }
    }
}