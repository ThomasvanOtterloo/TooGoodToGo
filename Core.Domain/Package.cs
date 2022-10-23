using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Package
    {
        
        public int Id { get; set; }

        public Student? Student { get; set; }
        public Canteen? Canteen { get; set; }
        public int? StudentId { get; set; }
        public int? CanteenId { get; set; }
       

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public City City { get; set; }
        
        public DateTime PickUp { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        public Meal Meal { get; set; }
        
        public DateTime AvailableUntil { get; set; }

        public List<Product>? Products { get; set; }

        public static DateOnly GetReadableDate(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
    }

}


