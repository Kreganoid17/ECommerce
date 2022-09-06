using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
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

        public async Task UpdateQuantity(List<CartDTO> cart)
        {
            try
            {

                foreach (var item in cart)
                {

                    var product = await _context.Products.FindAsync(item.ProductID);

                    product.Quantity -= item.Quantity;

                    await _context.SaveChangesAsync();

                }

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }

        public async Task<List<Product>> SearchProducts(string searchText)
        {
            try
            {

                return await _context.Products
                .Where(p => p.ProductName.Contains(searchText) || p.Description.Contains(searchText))
                .ToListAsync();

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }
    }
}
