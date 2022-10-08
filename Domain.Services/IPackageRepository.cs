﻿namespace Core.Domain.Services
{
    public interface IPackageRepository
    {
        IEnumerable<Package> GetAllPackages();

        IEnumerable<Package> GetAllAvailablePackages();
        IEnumerable<Package> GetAllSoldPackages(Student student);

        Package GetPackageById(int id);
        Task AddPackage(Package package);

        Task RemovePackage(Package package);
    }
}