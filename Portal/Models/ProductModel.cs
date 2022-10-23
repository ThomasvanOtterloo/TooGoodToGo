using Core.Domain.Services;
using Core.Domain;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Models
{
    public class ProductModel
    {
         public List<Product> ProductsList { get; set; }

        public SelectList ProductsItems
        {
            get => new SelectList(ProductsList, nameof(Product.Id), nameof(Product.Name));
        }

        public List<int>? Products { get; set; }


      
          public IEnumerable<Canteen> Canteens { get; set; }
        public SelectList CanteenItems {
            get => new SelectList(Canteens, nameof(Canteen.Id), nameof(Canteen.Name));
        }

        public int CanteenId { get; set; }


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public City City { get; set; }
        [Required]
        public DateTime PickUp { get; set; }
        [Required]
        public DateTime AvailableUntil { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Meal Meal { get; set; }
        public IEnumerable<Package> Packages { get; set; }
       

    }
        
}