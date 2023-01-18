using Core.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace WebApi.Models
{
    public class PackageDTO
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime PickUp { get; set; }
        public double Price { get; set; }
        public Meal Meal { get; set; }
        public DateTime AvailableUntil { get; set; }
        public List<ProductDTO>? Products { get; set; }
        public static DateOnly GetReadableDate(DateTime date)
        {
            return new DateOnly(date.Year, date.Month, date.Day);
        }

    }
}
