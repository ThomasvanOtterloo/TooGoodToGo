using Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class NewStudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [NotMapped]
        public DateOnly BirthDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public City City { get; set; }

    }
}
