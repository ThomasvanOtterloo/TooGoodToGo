using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class PackageProductsEFRepository
    {
        private readonly PackageDbContext _context;

        public PackageProductsEFRepository(PackageDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PackageProducts> GetAllProducts()
        {
            return _context.PackageProducts.ToList();
        }

        public PackageProducts GetProductById(int id)
        {
            return _context.PackageProducts.Find(id);
        }
    }
}
