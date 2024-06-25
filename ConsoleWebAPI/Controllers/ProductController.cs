using ConsoleWebAPI.Models;
using ConsoleWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductRepository _productRepository1;

        public ProductController(IProductRepository productRepository, 
            IProductRepository productRepository1)
        {
            this._productRepository = productRepository;
            this._productRepository1 = productRepository1;

        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            this._productRepository.AddProduct(product);
            List<ProductModel> products =  this._productRepository1.GetProducts();
            return Ok(products);
        }
    }
}
