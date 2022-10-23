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

        public Package GetPackageById(int id)
        {
            return _context.Packages.First(p => p.Id == id);
        }

        public Task CreatePackage(Package package)
        {
            _context.Packages.Add(package);
            return Task.CompletedTask;
        }

        public DbSet<Core.Domain.Package> Packages { get; set; }
        

        public IEnumerable<Package> GetAllAvailablePackages()
        {
            return _context.Packages.Where(p => p.StudentId == null).ToList();
        }

        public IEnumerable<Package> GetAllPackages()
        {
            return _context.Packages.ToList();
        }

        public IEnumerable<Package> GetAllSoldPackages(Student student)
        {
            return _context.Packages.Where(p => p.StudentId == student.Id).ToList();
        }

        public Task DeletePackage(int Id)
        {
            _context.Packages.Remove(_context.Packages.First(p => p.Id == Id));
            return Task.CompletedTask;
        }

        public Task UpdatePackage(Package package)
        {
            _context.Packages.Update(package);
            return Task.CompletedTask;
        }

      


    }
}
