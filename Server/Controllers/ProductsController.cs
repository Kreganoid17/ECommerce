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

            try
            {

                var Products = await _products.GetProducts();

                return Products;

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);

            }
        
        }

        [HttpGet("{Id}")]
        public async Task<Product> GetProduct(int Id)
        {

            try
            {

                var Products = await _products.GetProduct(Id);

                return Products;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }

    }
}
