using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface IPackageProductsRepository
    {
        IEnumerable<PackageProducts> GetAllProducts();
        PackageProducts GetProductById(int id);
 
    }
}
