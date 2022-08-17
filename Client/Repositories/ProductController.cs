using ECommerceApp.Client.Services;
using ECommerceApp.Shared;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class ProductController : IProductsController
    {
        private readonly HttpClient _client;

        public ProductController(HttpClient client)
        {
            _client = client;
        }

        public List<Product> products { get; set; }
        public Product product { get; set; }

        public async Task GetProducts()
        {
            try
            {

                var Products = await _client.GetFromJsonAsync<List<Product>>("api/Products");

                products = Products;

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);
            
            }

        }

        public async Task GetProduct(int Id)
        {
            try
            {

                var Product = await _client.GetFromJsonAsync<Product>($"api/Products/{Id}");

                product = Product;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }

    }
}
