using System.ComponentModel.DataAnnotations.Schema;




namespace Core.Domain
{
    public class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        

        //[AgeValidation(ErrorMessage = "Age must be 16 or older")]
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public City City { get; set; }

        public ICollection<Package>? Packages { get; set; }
   

       
        
    }
}
