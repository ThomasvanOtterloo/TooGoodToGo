using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Display(Name = "Contains alcohol")]
        public bool ContainsAlcohol { get; set; }
        public string? Image { get; set; }

        public ICollection<Package>? Packages { get; set; }
     
    }
}
