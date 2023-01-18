namespace Core.Domain.Services
{
    public interface IPackageRepository
    {
        IEnumerable<Package> GetAllPackages();

        IEnumerable<Package> GetAllPackagesByStudentCity(Student student);
        IEnumerable<Package> GetAllAvailablePackages();
        IEnumerable<Package> GetAllReservedPackagesByStudent(Student student);
      
        IEnumerable<Package> GetPackageCanteenFiltered(Canteen canteen);
        IEnumerable<Package> GetAllPackagesMealFiltered(Meal meal);
        IEnumerable<Package> GetAllPackagesAvailabilityFiltered(String option);
        IEnumerable<Package> GetAllReservedPackages();
        IEnumerable<Package> GetPackagesByFilter(City? city, Meal? meal, String availablity, int? canteen);

        Package GetPackageById(int? id);

        
        Task CreatePackage(Package package);

        Task DeletePackage(int id);

        Task UpdatePackage(Package package);

        Task ReservePackage(Package package, Student student);


        
    }
}
