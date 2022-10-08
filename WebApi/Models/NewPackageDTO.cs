using Core.Domain;

namespace WebApi.Models
{
    public class NewPackageDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public City City { get; set; }
        public Canteen? Canteen { get; set; }
        public DateTime PickUp { get; set; }
        public double Price { get; set; }
        public Meal Meal { get; set; }
        public bool Adult { get; set; }
        public Student? Sold { get; set; }
        public DateTime LastUntil { get; set; }

    }
}
