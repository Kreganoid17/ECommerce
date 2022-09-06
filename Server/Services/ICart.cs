using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface ICart
    {

        Task AddToCart(Cart cart);

        Task AddCartToDB(CartDBDTO cart);

        Task<List<CartDTO>> LoadCart(int userid);

        Task<List<Product>> GetProducts(List<ProductDTO> productdto);


    }
}
