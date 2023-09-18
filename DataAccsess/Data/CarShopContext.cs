using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarShop.Entities;
using CarShop.EntitiesConfiguration;
using DataAccsess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarShop.Data
{
    public class CarShopContext : IdentityDbContext<CustomUser>
    {
        public CarShopContext (DbContextOptions<CarShopContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfiguration());

            modelBuilder.Entity<Car>()
            .HasOne(c => c.Category)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.CategoryId);


            modelBuilder.Entity<Category>().HasData(SeedData.GetCategory());
            modelBuilder.Entity<Car>().HasData(SeedData.GetCars());
        }
        public DbSet<Car> Car { get; set; } = default!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Category { get; set; } = default!;
    }
}
