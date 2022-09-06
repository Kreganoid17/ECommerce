using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface IProducts
    {

        List<Product> products { get; set;}

        Product product { get; set; }

        public Task<List<Product>> GetProducts();

        public Task<Product> GetProduct(int Id);

        public Task UpdateQuantity(List<CartDTO> cart);

        public Task<List<Product>> SearchProducts(string searchText);

    }
}
