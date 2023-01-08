using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarbucksCoffee.Api.DataAccessLayer.Entities;

namespace StarbucksCoffee.Api.DataAccessLayer
{
    public class StarbucksCoffeeDbContext : DbContext
    {
        public StarbucksCoffeeDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Coffee> Coffeees { get; set; }

        public DbSet<Characteristic> Characteristics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coffee>()
                .HasMany(c => c.Characteristics)
                .WithMany(c => c.Coffees)
                .UsingEntity<Dictionary<string, object>>(
                    "CoffeeCharacteristic",
                    r => r.HasOne<Characteristic>().WithMany().HasForeignKey("CharacteristicId"),
                    l => l.HasOne<Coffee>().WithMany().HasForeignKey("CoffeeId"),
                    je =>
                    {
                        je.HasKey("CoffeeId", "CharacteristicId");
                        je.HasData(
                            new { CoffeeId = 1, CharacteristicId = 1 },
                            new { CoffeeId = 1, CharacteristicId = 2 },
                            new { CoffeeId = 2, CharacteristicId = 2 },
                            new { CoffeeId = 2, CharacteristicId = 3 },
                            new { CoffeeId = 3, CharacteristicId = 3 });
                    });
            modelBuilder.Entity<Characteristic>().HasMany(c => c.Coffees);
            modelBuilder.Entity<Coffee>()
                .HasData(
                            new Coffee { Id = 1, Type = "Starbucks Latte" },
                            new Coffee { Id = 2, Type = "Starbucks Macchiato" },
                            new Coffee { Id = 3, Type = "Starbucks Espresso" });
            modelBuilder.Entity<Characteristic>()
                .HasData(   
                            new Characteristic { Id = 1, Description = "extra cream" },
                            new Characteristic { Id = 2, Description = "brown sugar" },
                            new Characteristic { Id = 3, Description = "double shot" });
            modelBuilder.Entity<Coffee>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Characteristic>()
             .Property(p => p.Id)
             .ValueGeneratedOnAdd();
        }
        }
}
