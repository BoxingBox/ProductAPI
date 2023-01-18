﻿using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities;
using ProductAPI.Models;
using System;

namespace ProductAPI.DbContexts
{
    public class ProductContext : DbContext 

    {
        public DbSet<Products> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(new Products("Small Kitchen Knife")
            {
                Id = 1,
                Description = "A small kitchen knife used to gut fish",
                Price = 15.60M,
            },
                new Products("Large Kitchen Knife")
                {
                    Id = 2,
                    Description = "A large kitchen knife used to cut meat",
                    Price = 25.29M,
                },
                new Products("Cheese serving tray")
                {
                    Id = 3,
                    Description = "A serving tray used to serve cheese",
                    Price = 13.90M,
                },
                new Products("Pressure cooker")
                {
                    Id = 4, Description = "A pressure cooker that cuts your cooking time in half",
                    Price = 75.43M },
                new Products("Cast-Iron pan") 
                {
                    Id = 5, Description = "A cast iron pan used for cooking steak and fish",
                    Price = 45.10M 
                });
        }
    }
}
