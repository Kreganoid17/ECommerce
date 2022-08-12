using ECommerceApp.Shared;

namespace ECommerceApp.Client.Services
{
    public interface IProductsController
    {

        List<Product> products { get; set; }

        Product product { get; set; }

        Task GetProducts();

        Task GetProduct(int Id);

    }
}
