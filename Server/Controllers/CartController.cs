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
        public async Task AddToCart(Cart cart)
        {

            try
            {

                await _cart.AddToCart(cart);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        [HttpPost("AddCartToDB")]
        public async Task AddCartToDB(CartDBDTO cart)
        {
            try
            {

                await _cart.AddCartToDB(cart);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        [HttpGet("{Id}")]
        public Task<Product> GetProduct(int Id)
        {

            try
            {

                var product = _products.GetProduct(Id);

                return product;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        [HttpGet("LoadCart/{userid}")]
        public Task<List<CartDTO>> LoadCart(int userid)
        {

            try
            {

                var cartdto = _cart.LoadCart(userid);

                return cartdto;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }


        }

        [HttpPost("Quantity")]
        public async Task<List<Product>> Quantity(List<ProductDTO> productdto)
        {
            try
            {

                return await _cart.GetProducts(productdto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

    }

}
