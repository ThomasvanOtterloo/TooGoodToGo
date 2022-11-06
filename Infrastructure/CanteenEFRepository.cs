using Core.Domain;
using Core.Domain.Services;

namespace Infrastructure
{
    public class CanteenEFRepository : ICanteenRepository
    {

        private readonly PackageDbContext _context;

        public CanteenEFRepository(PackageDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Canteen> GetAllCanteens()
        {
            return _context.Canteens.ToList();
        }

        public Canteen GetCanteenById(int id)
        {
            return _context.Canteens.First(c => c.Id == id);
        }
    }
}