using Core.Domain;
using Core.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class PackageEFRepository : IPackageRepository
    {
        private readonly PackageDbContext _context;

        public PackageEFRepository(PackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Package GetPackageById(int? id)
        {
            return _context.Packages
                .Include(m => m.Products)
                .Include(m => m.Employee)
                .ThenInclude(m => m.Canteen)
                .First(m => m.Id == id);
        }


        public Task CreatePackage(Package package)
        {
            ValidatePackageAttributes(package);
            _context.Packages.Add(package);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdatePackage(Package package)
        {
            if (package.StudentId != null)
                throw new ArgumentException("Package is reserved and cannot be deleted or edited");
            ValidatePackageAttributes(package);
            _context.Update(package);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }


        private static void ValidatePackageAttributes(Package package)
        {
            if (package.PickUp > package.AvailableUntil || package.PickUp < DateTime.Now)
                throw new ArgumentException("Pick up date is not within the available until date");
            if (package.Price <= 0)
                throw new ArgumentException("Price must be greater than 0");
            if (package.Products.Count == 0)
                throw new ArgumentException("Package must contain at least one product");
            if (package.AvailableUntil < DateTime.Now)
                throw new ArgumentException("Available until date must be in the future");
            if (package.Name == null)
                throw new ArgumentException("Package must have a name");
            if (package.Description == null)
                throw new ArgumentException("Package must have a description");
        }




        public DbSet<Core.Domain.Package> Packages { get; set; }


        public IEnumerable<Package> GetAllAvailablePackages()
        {
            return _context.Packages.Where(p => p.StudentId == null)
                .Where(p => p.AvailableUntil > DateTime.Now)
                .Include(p => p.Products)
                .Include(o => o.Employee)
                .ThenInclude(c => c.Canteen)
                .OrderBy(p => p.PickUp)
                .ToList();
        }

        public IEnumerable<Package> GetAllPackagesByStudentCity(Student student)
        {
            return _context.Packages.Where(p => p.Employee.Canteen.City == student.City)
                    .Where(p => p.StudentId == null)
                    .Include(p => p.Products)
                    .Include(o => o.Employee)
                    .ThenInclude(c => c.Canteen)
                    .OrderBy(p => p.PickUp)
                    .ToList();
        }

        public IEnumerable<Package> GetAllPackages()
        {
            return _context.Packages
                .Include(p => p.Products)
                .Include(o => o.Employee)
                .ThenInclude(c => c.Canteen)
                .OrderBy(p => p.PickUp)
                .ToList();
        }

        public IEnumerable<Package> GetAllReservedPackagesByStudent(Student student)
        {
            return _context.Packages
                .Where(p => p.StudentId == student.Id)
                .Include(p => p.Products)
                .Include(o => o.Employee)
                .ThenInclude(c => c.Canteen)
                .OrderBy(p => p.PickUp)
                .ToList();
        }

        public IEnumerable<Package> GetAllReservedPackages()
        {
            return _context.Packages.Where(p => p.StudentId != null).ToList();
        }

        public Task DeletePackage(int Id)
        {
            if (GetPackageById(Id) == null)
                throw new ArgumentException("Package does not exist");
            if (GetPackageById(Id).StudentId != null)
                throw new ArgumentException("Package is reserved and cannot be deleted or edited");

            var test = GetPackageById(Id);

            _context.Packages.Remove(_context.Packages.First(p => p.Id == Id));
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task ReservePackage(Package package, Student student)
        {

            if (package == null)
                throw new ArgumentException("Package does not exist");
            if (package.StudentId != null)
                throw new ArgumentException("Box is already reserved, Please take a look at our available boxes");
            if (student.BirthDate > package.PickUp.AddYears(-18))
                throw new ArgumentException("Student is not old enough to reserve this box");
            if (GetAllReservedPackagesByStudent(student).Any(p => p.PickUp.Date == package.PickUp.Date))
                throw new ArgumentException("You already reserved a box on that day today. You are limited to 1 box a day.");

            package.StudentId = student.Id;

            _context.Update(package);
            _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public IEnumerable<Package> GetPackageCanteenFiltered(Canteen canteen)
        {
            return _context.Packages.Where(p => p.Employee.CanteenId == canteen.Id).Where(d => d.AvailableUntil > DateTime.Now).ToList();
        }

        public IEnumerable<Package> GetAllPackagesMealFiltered(Meal meal)
        {
            return _context.Packages.Where(p => p.Meal == meal).Where(p => p.AvailableUntil > DateTime.Now).ToList();
        }

        public IEnumerable<Package> GetAllPackagesAvailabilityFiltered(String option)
        {
            if (option == "Available")
                return _context.Packages.Where(p => p.StudentId == null).Where(p => p.AvailableUntil > DateTime.Now).ToList();
            if (option == "Reserved")
                return _context.Packages.Where(p => p.StudentId != null).ToList();
            if (option == "All")
                return _context.Packages.ToList();
            return null;
        }


        public IEnumerable<Package> GetPackagesByFilter(City? city, Meal? meal, String availability, int? canteen)
        {

            IQueryable<Package> packages = _context.Packages.Where(p => p.AvailableUntil > DateTime.Now)
                .Include(p => p.Products)
                .Include(p => p.Employee)
                .ThenInclude(e => e.Canteen);


            if (city != null)
                packages = packages.Where(p => p.Employee.Canteen.City == city).OrderBy(p => p.PickUp);
            if (meal != null)
                packages = packages.Where(p => p.Meal == meal).OrderBy(p => p.PickUp);
            if (availability == "Available")
                packages = packages.Where(p => p.StudentId == null).OrderBy(p => p.PickUp);
            if (availability == "Reserved")
                packages = packages.Where(p => p.StudentId != null).OrderBy(p => p.PickUp);
            if (availability == "All")
                packages = packages.OrderBy(p => p.PickUp);
            if (canteen != null)
                packages = packages.Where(p => p.Employee.Canteen.Id == canteen).OrderBy(p => p.PickUp);
            return packages.ToList();
        }





    }
}
