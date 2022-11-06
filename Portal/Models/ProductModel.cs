using Core.Domain.Services;
using Core.Domain;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;

namespace Portal.Models
{
    public class ProductModel
    {
     

        public IEnumerable<Canteen> Canteens { get; set; }

        public Employee Employee { get; set; }

        public int CanteenId { get; set; }




        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please enter a City")]
        public City City { get; set; }
       
        [Required(ErrorMessage = "Please enter a Pick up Date")]
        public DateTime PickUp { get; set; }
        
        public DateTime AvailableUntil { get => DateTime.Now.AddDays(3); }

        [Required(ErrorMessage = "Please enter a Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please enter a Meal type")]
        public Meal Meal { get; set; }
        public IEnumerable<Package> Packages { get; set; }
       
        public List<Product>? ProductsList { get; set; }

        public SelectList ProductsItems
        {
            get => new(ProductsList, nameof(Product.Id), nameof(Product.Name));
        }

        [Required(ErrorMessage = "Please select atleast 1 product")]
        public List<Product> Products { get; set; }
        public List<int> ProductIds { get; set; }


    }

}