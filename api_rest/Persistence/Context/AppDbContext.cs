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
            builder.Entity<Category>().HasKey(p => p.IdCategory);
            builder.Entity<Category>().Property(p => p.IdCategory).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.IdCategory);

            builder.Entity<Category>().HasData
            (
                new Category { IdCategory = 100, Name = "Fruits and Vegetables" }, 
                new Category { IdCategory = 101, Name = "Dairy" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.IdProduct);
            builder.Entity<Product>().Property(p => p.IdProduct).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
            builder.Entity<Product>().Property(p => p.IdCategory);

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    IdProduct = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    IdCategory = 100
 
                },
                new Product
                {
                    IdProduct = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    IdCategory = 101,
                }
            );

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.IdUser);
            builder.Entity<User>().Property(p => p.IdUser).ValueGeneratedOnAdd().IsRequired();
            builder.Entity<User>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<User>().Property(p => p.Login).HasMaxLength(15).IsRequired();
            builder.Entity<User>().Property(p => p.Password).HasMaxLength(12).IsRequired();

            builder.Entity<User>().HasData(
                new User
                {
                    IdUser = 1,
                    Name = "Lucas",
                    Login = "LucasMaia",
                    Password = "12345",
                },
                new User
                {
                    IdUser = 2,
                    Name = "Mateus",
                    Login = "MateusTales",
                    Password = "98765",
                });

        }
    }

}
