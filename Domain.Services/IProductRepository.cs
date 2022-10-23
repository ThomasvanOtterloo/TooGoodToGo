using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Task CreateProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(int id);

    }
}
