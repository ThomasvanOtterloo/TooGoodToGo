using Core.Domain;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<Package>().HasData(
            new Package() { Id = 1, Name = "Verse Maccoroni",Description= "Dit is lekkere Maccie dik vettie", IsAdult = true, },
            new Package() { Id = 2, Name = "Pizza1", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false },
            new Package() { Id = 3, Name = "Pizza2", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false },
            new Package() { Id = 4, Name = "Pizza3", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false },
            new Package() { Id = 5, Name = "Pizza4", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false },
            new Package() { Id = 6, Name = "Verse Pizza1", Description = "Dit is lekkere Maccie dik vettie", IsAdult = true },
            new Package() { Id = 7, Name = "Pizza5 ", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false, City = City.Breda, Meal = Meal.Dinner },
            new Package() { Id = 8, Name = "test", Description = "Dit is lekkere Maccie dik vettie", IsAdult = false, City = City.Breda, Meal = Meal.Dinner });

            modelBuilder.Entity<Student>().HasIndex(o => o.Name).IsUnique();

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Elsa", EmployeeNumber = 8392, });

            modelBuilder.Entity<Canteen>().HasData(
                new Canteen { Id = 1, Location = "LA", IsHotMeal = true },
                new Canteen { Id = 2, Location = "LD", IsHotMeal = false }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Thomas", PhoneNumber = "06-11225039" },
                new Student { Id = 2, Name = "Roberto", PhoneNumber = "06-11225031" }
            );
            
            //modelBuilder.Entity<Student>().HasData(
            //    new Student { Id = 1, Name = "Thomas", BirthDate = new DateOnly(1999, 12, 29), City = City.Breda, Login = { Email = "test@gmail.com", Password = "qwerty!123" }, PhoneNumber = "06-11225039" },
            //    new Student { Id = 2, Name = "Roberto", BirthDate = new DateOnly(1999, 12, 29), City = City.Breda, Login = { Email = "test1@gmail.com", Password = "qwerty!123" }, PhoneNumber = "06-11225031" }
            //);

        }
    }
}
