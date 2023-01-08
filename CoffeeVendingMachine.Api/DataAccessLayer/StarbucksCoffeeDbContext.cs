using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StarbucksApi.DataAccessLayer.Entities;

namespace StarbucksApi.DataAccessLayer
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
                 .HasMany(x => x.Characteristics)
                 .WithMany(x => x.Coffees)
                 .UsingEntity(j => j.HasData
                        (
                            new { CoffeesId = 1, CharacteristicsId = 1 },
                            new { CoffeesId = 1, CharacteristicsId = 2 },
                            new { CoffeesId = 2, CharacteristicsId = 2 },
                            new { CoffeesId = 2, CharacteristicsId = 3 },
                            new { CoffeesId = 3, CharacteristicsId = 3 }
                        ));
                 

           
            modelBuilder.Entity<Coffee>()
               .Property(p => p.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Characteristic>()
                 .Property(p => p.Id)
                 .ValueGeneratedOnAdd();
        }
    }
}
