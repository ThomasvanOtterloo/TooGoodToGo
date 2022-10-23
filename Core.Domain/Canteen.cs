namespace Core.Domain
{
    public class Canteen
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public City City { get; set; }

        public Boolean OfferHotMeals { get; set; }

        public ICollection<Package>? Packages { get; set; }


    }
}