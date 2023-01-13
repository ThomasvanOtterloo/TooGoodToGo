using Core.Domain;

namespace Portal.Models
{
    public static class PackageExtensions
    {
        public static bool HasPassedPickUpDate(this Package package)
        {
            return package.PickUp <= DateTime.Now;
        }
    }
}

