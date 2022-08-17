using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.Repositories
{
    public class Products : IProducts
    {

        private readonly DataContext _context;

        public Products(DataContext context)
        {
            _context = context;
        }

        public List<Product> products { get; set; }

        public Product product { get; set; }

        public async Task<Product> GetProduct(int Id)
        {
            try
            {

                var Product = await _context.Products.FindAsync(Id);

                product = Product;

                return product;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {

                var Products = await _context.Products.ToListAsync();

                products = Products;

                return products;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }

    }
}
