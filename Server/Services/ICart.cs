using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface ICart
    {

        Task AddToCart(Cart cart);

        Task AddCartToDB(List<CartDTO> cartdto);


    }
}
