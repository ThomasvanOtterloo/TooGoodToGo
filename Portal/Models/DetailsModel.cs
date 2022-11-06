

using Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Portal.Models
{
    public class DetailsModel
    {
        public Package? Package { get; set; }

        public List<Product> Products { get; set; }
       

        public string CanteenName { get; set; }

        [Display(Name = "Contains alcohol")]
        public bool ContainsAlcohol { get; set; } = false;

        public string ImageUrl { get; set; } = "https://usercontent.one/wp/www.maison-viridi.com/wp-content/uploads/2020/03/sinpel-brood-1140x760.jpg";

        public bool Editable { get; set; } = false;
    }
}
