using Core.Domain;

namespace Portal.Models
{
    public class UpdatePackageModel
    {
        
        public string? Name { get; set; }

       
        public string? Description { get; set; }

        
        public City City { get; set; }

        public int CanteenId { get; set; }

        public DateTime PickUp { get; set; }

        public double Price { get; set; }

        public Meal Meal { get; set; }

        public List<int>? Products { get; set; } = new List<int>();
    }
}
