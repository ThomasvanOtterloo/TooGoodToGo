using Core.Domain;

namespace Portal.Models
{
    public static class ViewModelHelpers
    {
        public static List<PackageViewModel> ToViewModel(this IEnumerable<Package> packages)
        {
            var result = new List<PackageViewModel>();

            foreach (var package in packages)
            {
                result.Add(package.ToViewModel());
            }

            return result;
        }

        public static PackageViewModel ToViewModel(this Package package)
        {
            var result = new PackageViewModel
            {
                Id = package.Id,
                Name = package.Name,
                Adult = package.IsAdult,
                Price = package.Price,
                Description = package.Description,
                Canteen = package.Canteen,
                SoldTo = package.ReservedTo,
                Meal = package.Meal,
                City = package.City,
                LastUntil = package.AvailableUntil,
                PickUp = package.PickUp,
                /* LastUntil = package.LastUntil,*/
            };

            return result;
        }
    }
}
