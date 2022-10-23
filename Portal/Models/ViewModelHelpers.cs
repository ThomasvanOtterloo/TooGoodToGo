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
                StudentId = package.StudentId ?? 0,
                CanteenId = package.CanteenId ?? 0,
                Name = package.Name,
                Price = package.Price,
                Description = package.Description,
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
