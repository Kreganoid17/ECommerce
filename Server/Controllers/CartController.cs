using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cart;
        private readonly IProducts _products;

        public CartController(ICart cart, IProducts products)
        {
            _cart = cart;
            _products = products;
        }

        [HttpPost("AddToCart")]
        public async Task AddToCart(Cart cart) {

            try
            {

                await _cart.AddToCart(cart);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }
        
        }

        [HttpPost("AddCartToDB")]
        public async Task AddCartToDB(List<CartDTO> carddto)
        {
            try
            {

                await _cart.AddCartToDB(carddto);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

        [HttpGet("{Id}")]
        public Task<Product> GetProduct(int Id) {

            try
            {

                var product = _products.GetProduct(Id);

                return product;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

    }
}
