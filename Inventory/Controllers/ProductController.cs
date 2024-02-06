using Inventory.Domain;
using Inventory.DTO;
using Inventory.Interfaces;
using Inventory.Model;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("products")]

    public class ProductController : Controller
    {
        private readonly IProductService _productRepository;
        public ProductController(IProductService productrepository)
        {
            _productRepository = productrepository;
        }

        [HttpGet("getAll")]
        public ICollection<ViewProduct> GetAllProducts()
        {
            return _productRepository.GetAllProduct();
        }

        [HttpGet("get/{id}")]
        public ViewProduct GetProduct(Guid id)
        {
            return _productRepository.GetProductById(id);
        }

        [HttpPut("add")]
        public Guid AddProduct([FromBody] PostProduct prod)
        {
            return _productRepository.AddProduct(prod);
        }

        [HttpDelete("delete")]
        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
        }

        [HttpPatch("update/{id}")]
        public void UpdateProduct(Guid id, [FromBody] PostProduct prod)
        {
            _productRepository.UpdateProduct(id, prod);
        }
    }
}
