using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Infrastructure
{
    public class PackageDbContext : DbContext
    {
        //private readonly UserManager<IdentityUser> _userManager;
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<PackageProducts> PackageProducts { get; set; }

        public PackageDbContext(DbContextOptions<PackageDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PackageProducts>()
                .HasKey(pp => new { pp.PackageId, pp.ProductId });


            modelBuilder.Entity<ReservedPackage>()
                .HasKey(rp => new { rp.PackageId, rp.StudentId });


            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasOne(p => p.Student).WithMany(s => s.Packages).HasForeignKey(p => p.StudentId);
                entity.HasOne(p => p.Canteen).WithMany(c => c.Packages).HasForeignKey(p => p.CanteenId);
                entity.HasMany(p => p.Products).WithMany(p => p.Packages);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasMany(p => p.Packages).WithMany(p => p.Products);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasMany(s => s.Packages).WithOne(p => p.Student).HasForeignKey(p => p.StudentId);
            });

            modelBuilder.Entity<Canteen>(entity =>
            {
                entity.HasMany(c => c.Packages).WithOne(p => p.Canteen).HasForeignKey(p => p.CanteenId);
            });

            



            modelBuilder.Entity<Canteen>().HasData(
               new Canteen
               {
                   Id = 1,
                   Name = "LA",
                   City = City.Breda,
                   OfferHotMeals = true,
               },
               new Canteen
               {
                   Id = 2,
                   Name = "LD 2",
                   City = City.Breda,
                   OfferHotMeals = false,
               });



            modelBuilder.Entity<PackageProducts>().HasData(

                new PackageProducts { PackageId = 1, ProductId = 1 },
                new PackageProducts { PackageId = 1, ProductId = 2 },
                new PackageProducts { PackageId = 1, ProductId = 3 },
                new PackageProducts { PackageId = 1, ProductId = 4 },

                new PackageProducts { PackageId = 2, ProductId = 1 },
                new PackageProducts { PackageId = 2, ProductId = 2 },
                new PackageProducts { PackageId = 2, ProductId = 3 }
                );

            modelBuilder.Entity<ReservedPackage>().HasData(

                    new ReservedPackage { PackageId = 1, StudentId = 1 },
                    new ReservedPackage { PackageId = 2, StudentId = 1 }
                    );


            modelBuilder.Entity<Student>().HasData(
              new Student
              {
                  Id = 1,
                  Name = "Student 1",
                  BirthDate = new DateOnly(2000, 1, 1),
                  PhoneNumber = "0612345678",
                  City = City.Tilburg
              },
              new Student
              {
                  Id = 2,
                  Name = "Student 2",
                  BirthDate = new DateOnly(2000, 1, 1),
                  PhoneNumber = "0612345678",
                  City = City.Breda
              });




            modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    Id = 1,
                    StudentId = 1,
                    CanteenId = 1,
                    Name = "Package 1",
                    Description = "This is a package",
                    City = City.Breda,
                    PickUp = DateTime.Now,
                    Price = 10.00,
                    Meal = Meal.Dinner,
                    AvailableUntil = DateTime.Now.AddDays(3)
                },
                new Package
                {
                    Id = 2,
                    StudentId = 1,
                    CanteenId = 1,
                    Name = "Package 2",
                    Description = "This is a package",
                    City = City.Breda,
                    PickUp = DateTime.Now,
                    Price = 10.00,
                    Meal = Meal.Dinner,
                    AvailableUntil = DateTime.Now.AddDays(3),
        
                },
                new Package
                {
                    Id = 3,
                    StudentId = 2,
                    Name = "Package 3",
                    Description = "This is a package",
                    City = City.Tilburg,
                    PickUp = DateTime.Now,
                    Price = 10.00,
                    Meal = Meal.Dinner,
                    AvailableUntil = DateTime.Now.AddDays(3),
                
                },
                new Package
                {
                    Id = 4,
                    StudentId = 2,
                    Name = "Package 4",
                    Description = "This is a package",
                    City = City.Tilburg,
                    PickUp = DateTime.Now,
                    Price = 10.00,
                    Meal = Meal.Dinner,
                    AvailableUntil = DateTime.Now.AddDays(3),
                    
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                },
                new Product
                {
                    Id = 5,
                    Name = "Product 5",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                },
                new Product
                {
                    Id = 6,
                    Name = "Product 6",
                    ContainsAlcohol = false,
                    Image = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.ah.nl%2Fproducten%2Fproduct%2Fwi"
                });







        }
    }
}

