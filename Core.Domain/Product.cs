namespace Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool AlcoholIncluded { get; set; }
        public string? Image { get; set; }
    }
}
