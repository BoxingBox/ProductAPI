using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using ProductAPI.Models;
using System;

namespace ProductAPI.DbContexts
{
    public class ProductContext : DbContext

    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product("Small Kitchen Knife") { Id = 1, Description = "A small kitchen knife used to gut fish", Price = 15.60M, },
                new Product("Large Kitchen Knife") { Id = 2, Description = "A large kitchen knife used to cut meat", Price = 25.29M, },
                new Product("Cheese serving tray") { Id = 3, Description = "A serving tray used to serve cheese", Price = 13.90M, },
                new Product("Pressure cooker") { Id = 4, Description = "A pressure cooker that cuts your cooking time in half", Price = 75.43M },
                new Product("Cast-Iron pan") { Id = 5, Description = "A cast iron pan used for cooking steak and fish", Price = 45.10M });
        }
    }
}
