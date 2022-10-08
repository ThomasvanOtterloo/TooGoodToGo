using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public DateOnly BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public City City { get; set; }

        public Login Login { get; set;}
        
    }
}
