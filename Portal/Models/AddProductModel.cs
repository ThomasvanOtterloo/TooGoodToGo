using Core.Domain;
using System.ComponentModel.DataAnnotations;

namespace Portal.Models
{
    public class CreatePackageModel
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Please select a city")]
        public City City { get; set; }

        public int CanteenId { get; set; }

        public DateTime PickUp { get; set; }

        public double Price { get; set; }

        public Meal Meal { get; set; }

        public List<int>? Products { get; set; } = new List<int>();
    }
}