using Core.Domain;

namespace Portal.Models
{
    public class DetailsModel
    {
        public PackageProducts PackageProducts { get; set; }
        public Package? Package { get; set; }
        public IEnumerable<PackageProducts>? Products { get; set; }

        public string CanteenName { get => "test"; }
    }
}
