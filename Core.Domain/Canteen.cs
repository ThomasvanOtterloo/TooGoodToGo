namespace Core.Domain
{
    public class Canteen
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public City City { get; set; }

        public Boolean OfferHotMeals { get; set; }

       

        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }







    }
}