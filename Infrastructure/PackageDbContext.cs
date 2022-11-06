using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace Infrastructure
{
    public class PackageDbContext : DbContext
    {
     
        public DbSet<Canteen> Canteens { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employee { get; set; }
        
        public PackageDbContext(DbContextOptions<PackageDbContext> contextOptions) : base(contextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<ReservedPackage>()
                .HasKey(rp => new { rp.PackageId, rp.StudentId });


          

            modelBuilder.Entity<Package>(entity =>
            {
                entity.HasOne(p => p.Student).WithMany(s => s.Packages).HasForeignKey(p => p.StudentId);
                entity.HasOne(p => p.Employee).WithMany(c => c.Packages).HasForeignKey(p => p.EmployeeId);
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
            
                entity.HasOne(c => c.Employee).WithOne(p => p.Canteen).HasForeignKey<Employee>(p => p.CanteenId);
            });

            modelBuilder.Entity<Student>()
            .HasIndex(account => account.Email)
              .IsUnique();

            modelBuilder.Entity<Canteen>().HasData(
               new Canteen
               {
                   Id = 1,
                   LocationName = "LA",
                   EmployeeId = 1,
                   OfferHotMeals = true,
                   City = City.Breda

               },
               new Canteen
               {
                   Id = 2,
                   LocationName = "LB",
                   EmployeeId = 2,
                   OfferHotMeals = false,
                   City = City.Den_Bosch
               });;

            modelBuilder.Entity<ReservedPackage>().HasData(

                    new ReservedPackage { PackageId = 1, StudentId = 1 },
                    new ReservedPackage { PackageId = 2, StudentId = 1 }
                    );

            modelBuilder.Entity<Student>().HasData(
              new Student
              {
                  Id = 1,
                  Name = "Student 1",
                  Email = "Student1@gmail.com",
                  BirthDate = new DateTime(2000, 1, 1),
                  PhoneNumber = "0612345678",
                  City = City.Tilburg
              },
              new Student
              {
                  Id = 2,
                  Name = "Student 2",
                  Email = "Student2@gmail.com",
                  BirthDate = new DateTime(2000, 1, 1),
                  PhoneNumber = "0612345678",
                  City = City.Breda
              });

            modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = 1,
                  Name = "John Lee",
                  Email = "Admin@gmail.com",
                  EmployeeNumber = 13242321,
                  CanteenId = 1,
                  
              },
              new Employee
              {
                  Id = 2,
                  Name = "James Lee",
                  Email = "Employee2@gmail.com",
                  EmployeeNumber = 1223334,
                  CanteenId = 2,

              }
              );

            
            
            var product1 = new Product
            {
                Id = 1,
                Name = "Bread",
                ContainsAlcohol = false,
                Image = "https://i0.wp.com/www.vickyvandijk.nl/wp-content/uploads/2020/04/Vicky-van-Dijk-Knapperig-wit-brood-03.jpg?fit=1500%2C2100&ssl=1"
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Soup",
                ContainsAlcohol = false,
                Image = "https://familieoverdekook.nl/wp-content/uploads/2020/05/soep-met-courgette-en-tomaat.jpg"
            };

            modelBuilder.Entity<Package>().HasData(
                new Package
                {
                    Id = 1,
                    Name = "Suprise Box",
                    Description = "This box contains a surprise",
                    PickUp = DateTime.Now.AddDays(1),
                    Price = 10.00,
                    EmployeeId = 1,
                    Meal = Meal.Breakfast,
                    AvailableUntil = DateTime.Now.AddDays(3),
                 
                },
                new Package
                {
                    Id = 2,
                    
                  
                    Name = "Bread Box",
                    Description = "Half of the box is filled with bread",
                    EmployeeId = 1,
                    PickUp = DateTime.Now.AddDays(1),
                    Price = 10.00,
                    Meal = Meal.Breakfast,
                    AvailableUntil = DateTime.Now.AddDays(3),
                  
                },
                new Package
                {
                    Id = 3,
                  
                    Name = "Soup Box",
                    Description = "Alot of fresh left over soup ready to be served for dinner!",
                    EmployeeId = 1,
                    PickUp = DateTime.Now.AddDays(1),
                    Price = 10.00,
                    Meal = Meal.Dinner,
                    AvailableUntil = DateTime.Now.AddDays(3),

                },
                new Package
                {
                    Id = 4,
                    
                   
                    Name = "Gourmet Box",
                    Description = " This box contains a gourmet meal",
                    Meal = Meal.Dinner,
                    PickUp = DateTime.Now.AddDays(1),
                    Price = 10.00,
                    EmployeeId = 2,
                    AvailableUntil = DateTime.Now.AddDays(3)
                }
                );

           

            modelBuilder.Entity<Product>().HasData(
               product1,
               product2
                ,
                new Product
                {
                    Id = 3,
                    Name = "pasta",
                    ContainsAlcohol = false,
                    Image = "https://www.lekkerensimpel.com/wp-content/uploads/2022/08/588A2242.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Beer",
                    ContainsAlcohol = true,
                    Image = "https://brouwerijtroost.nl/wp-content/uploads/IMG_9831-1200x1200.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "sla",
                    ContainsAlcohol = false,
                    Image = "https://img.static-rmg.be/a/view/q75/w620/h336/4563344/gettyimages-1317960485-jpg.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Pizza",
                    ContainsAlcohol = false,
                    Image = "https://www.oetker.nl/Recipe/Recipes/oetker.nl/nl-nl/miscellaneous/image-thumb__97330__RecipeDetail/pizza-caprese.jpg"
                });

            modelBuilder.Entity<Package>()
                  .HasMany(p => p.Products)
                  .WithMany(p => p.Packages)
                  .UsingEntity(j => j.HasData(
                    new { PackagesId = 1, ProductsId = 1 },
                    new { PackagesId = 1, ProductsId = 2 },
                    new { PackagesId = 2, ProductsId = 3 },
                    new { PackagesId = 2, ProductsId = 4 },
                    new { PackagesId = 3, ProductsId = 5 },
                    new { PackagesId = 3, ProductsId = 6 },
                    new { PackagesId = 4, ProductsId = 1 },
                    new { PackagesId = 4, ProductsId = 2 },
                    new { PackagesId = 4, ProductsId = 3 },
                    new { PackagesId = 4, ProductsId = 4 }
             ));

        }
    }
}

