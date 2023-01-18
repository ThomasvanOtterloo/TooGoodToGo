using Core.Domain;
using Core.Domain.Services;


namespace WebAPIGraphQL.GraphQL
{
    public class PackageQuery
    {
        private readonly IPackageRepository _packageRepository;

        public PackageQuery(IPackageRepository _packageRepository)
        {
            this._packageRepository = _packageRepository;
        }
        public IEnumerable<Package> Package => _packageRepository.GetAllPackages();

       
    }
}
