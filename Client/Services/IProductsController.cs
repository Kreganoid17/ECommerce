using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface IProductsController
    {

        List<Product> products { get; set; }

        Product product { get; set; }

        Task GetProducts();

        Task GetProduct(int Id);

        Task UpdateQuantity(List<CartDTO> cart);

        Task<List<Product>> SearchProducts(string searchText);

    }
}
