using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Package
    {
        
        public int Id { get; set; }

        public Student? Student { get; set; }
       
        public int? StudentId { get; set; }
        


        [Required(ErrorMessage = "Please enter a name")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }

        [Display(Name = "Pick up at")]
        public DateTime PickUp { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }
        public Meal Meal { get; set; } 

        [Display(Name = "Available until")]
        public DateTime AvailableUntil { get; set; }
        public List<Product>? Products { get; set; }

        public static DateOnly GetReadableDate(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }
    }

}


