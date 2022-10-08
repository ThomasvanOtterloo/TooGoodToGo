using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Package
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public City City { get; set; }
        public Canteen? Canteen { get; set; }
        public DateTime PickUp { get; set; }
        public double Price { get; set; }
        public Meal Meal { get; set; }
        public bool IsAdult { get; set; }
        public Student? ReservedTo { get; set; }
        public DateTime AvailableUntil { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        public static DateOnly GetReadableDate(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
    }

}
