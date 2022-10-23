using Core.Domain.Services;
using Core.Domain;
namespace Infrastructure
{
    public class ProductEFRepository : IProductRepository
    {
        private readonly PackageDbContext _context;

        public ProductEFRepository(PackageDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int id)
        {
            _context.Products.Remove(_context.Products.First(p => p.Id == id));
            return Task.CompletedTask;
        }
        
        


    }
}
