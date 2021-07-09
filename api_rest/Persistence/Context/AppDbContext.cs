using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api_rest.Domain.Models;
using api_rest.Domain.Helpers;

namespace api_rest.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData(
                new Category { Id = 100, Name = "Fruits and Vegetables" },
                new Category { Id = 101, Name = "Dairy" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.CategoryId);
            

            builder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 200, 
                    Name = "Maça", 
                    CategoryId = 100, 
                    QuantityInPackage = 200,
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram
                },
                new Product 
                { 
                    Id = 201, 
                    Name = "Banana", 
                    CategoryId = 100, 
                    QuantityInPackage = 500,
                    UnitOfMeasurement = EUnitOfMeasurement.Kilogram
                }
                
                
            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Login).HasMaxLength(15).IsRequired();
            builder.Entity<User>().Property(p => p.Password).HasMaxLength(12).IsRequired();

            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Lucas",
                    Login = "LucasMaia",
                    Password = "12345",
                },
                new User
                {
                    Id = 2,
                    Name = "Mateus",
                    Login = "MateusTales",
                    Password = "98765",
                });

        }
    }

}
