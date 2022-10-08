namespace Core.Domain.Services
{
    public interface ICanteenRepository
    {
        public Canteen GetCanteenById(int id);

        public IEnumerable<Canteen> GetAllCanteens();
    }
}
