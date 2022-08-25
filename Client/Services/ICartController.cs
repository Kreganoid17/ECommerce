using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface ICartController
    {

        Task AddToCart(Product product);

        List<Product> CartItems { get; set; }

        Task AddCartToDB(List<CartDTO> cartdto);

        Task PopulateCart(List<CartDTO> cartdto);

        Task RemoveFromCart(Product cartdto);

    }
}
