using Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Models
{
    public class PackageIndexModel
    {
        public IEnumerable<Package> Packages { get; set; }

        public Package? Package { get; set; }

        public IEnumerable<Canteen> Canteens { get; set; }

        public List<SelectListItem> CanteenList { get; set; }
        public int CanteenId { get; set; }

    }
}
