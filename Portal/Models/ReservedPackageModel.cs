using Core.Domain;

namespace Portal.Models
{
    public class ReservedPackageModel
    {
        public Student Student { get; set; }
        public Package Package { get; set; }
        public IEnumerable<Package> Packages { get; set; }
    }
}
