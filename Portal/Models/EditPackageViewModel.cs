using Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Portal.Models
{
    public class EditPackageViewModel
    {

        // --------------------- detialsmodel
        public Package? Package { get; set; }

        public List<Product> ProductsGet { get; set; }


        public string CanteenName { get; set; }


        public bool ContainsAlcohol { get; set; }

        




        // ----------------------------productsmodel

        public IEnumerable<Canteen> Canteens { get; set; }

        public string? Name { get; set; }


  
        public string Description { get; set; }

        public DateTime PickUp { get; set; }

        public double Price { get; set; }

    
        public Meal Meal { get; set; }
        public IEnumerable<Package> Packages { get; set; }

        public List<Product>? ProductsList { get; set; }

        public SelectList ProductsItems
        {
            get => new(ProductsList, nameof(Product.Id), nameof(Product.Name));
        }

     
        public List<Product> Products { get; set; }
        public List<int> ProductIds { get; set; }
        
        public List<SelectListItem> Meals { get; set; }

    }
}
