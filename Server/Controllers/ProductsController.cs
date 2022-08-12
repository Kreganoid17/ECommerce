using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _products;

        public ProductsController(IProducts products)
        {
            _products = products;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() {

            var Products = await _products.GetProducts();

            return Products;
        
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Product>> GetProduct(int Id)
        {

            var Products = await _products.GetProduct(Id);

            return Products;

        }

    }
}
