using ECommerceApp.Shared;

namespace ECommerceApp.Server.Services
{
    public interface IProducts
    {

        List<Product> products { get; set;}

        Product product { get; set; }

        public Task<List<Product>> GetProducts();

        public Task<Product> GetProduct(int Id);

    }
}
