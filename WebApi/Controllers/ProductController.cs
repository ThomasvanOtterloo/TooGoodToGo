using Core.Domain;
using Core.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts().ToList());
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
            return Ok(product);
        }

        [HttpPut]
        public ActionResult<Product> UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
            return Ok();
        }

       
        
    }
}
