using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface ICartController
    {

        public event Action OnCartChange;
        public event Action OnProductChange;

        Task AddToCart(Product product);

        List<Product> CartItems { get; set; }

        Task AddCartToDB(CartDBDTO cart);

        Task PopulateCart(List<CartDTO> cartdto);

        Task RemoveFromCart(Product cartdto);

        Task<List<CartDTO>> LoadCart(int userid);

        Task<List<Product>> GetProducts(List<ProductDTO> productdto);

    }
}
