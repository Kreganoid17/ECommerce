using Blazored.LocalStorage;
using ECommerceApp.Client.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class CartController  : ICartController
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localstorage;

        public event Action OnCartChange;
        public event Action OnProductChange;

        public CartController(HttpClient client, ILocalStorageService localstorage)
        {

            _client = client;
            _localstorage = localstorage;

        }

        public List<Product> CartItems { get; set; }

        public async Task AddCartToDB(CartDBDTO cart)
        {

            try
            {

                await _client.PostAsJsonAsync("api/Cart/AddCartToDB", cart);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

        public async Task AddToCart(Product product)
        {
            try
            {

                var cart = await _localstorage.GetItemAsync<List<CartDTO>>("cart");

                if (cart == null)
                {

                    cart = new List<CartDTO>();

                }
                else
                {

                    var userid = await _localstorage.GetItemAsync<AuthDTO>("User");

                    CartDTO newCart = new CartDTO();

                    newCart.ProductID = product.ProductID;
                    newCart.Quantity = 1;
                    newCart.ProductName = product.ProductName;
                    newCart.Price = product.Price;
                    newCart.UserID = userid.UserID;

                    cart.Add(newCart);
                    await _localstorage.SetItemAsync("cart", cart);

                    OnCartChange.Invoke();
                    OnProductChange.Invoke();

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }

        public async Task RemoveFromCart(Product cartdto) {

            try
            {

                var cart = await _localstorage.GetItemAsync<List<CartDTO>>("cart");

                if (cart == null)
                {

                    return;

                }
                else {

                    var cartitem = cart.Find(x => x.ProductID == cartdto.ProductID);
                    cart.Remove(cartitem);

                    await _localstorage.SetItemAsync("cart", cart);

                    OnCartChange.Invoke();

                }

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);
            
            }
        
        }

        public async Task PopulateCart(List<CartDTO> cartdto) {

            try
            {

                List<Product> products = new List<Product>();

                foreach (var cartitem in cartdto)
                {

                    var item = await _client.GetFromJsonAsync<Product>($"api/Cart/{cartitem.ProductID}");

                    if (item != null)
                    {

                        Product product = new Product();

                        product.ProductID = cartitem.ProductID;
                        product.ProductName = cartitem.ProductName;
                        product.Price = cartitem.Price;
                        product.Quantity = cartitem.Quantity;

                        products.Add(product);

                    }

                }

                CartItems = products;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

        public async Task<List<CartDTO>> LoadCart(int userid) {

            var item = await _client.GetFromJsonAsync<List<CartDTO>>($"api/Cart/LoadCart/{userid}");

            List<Product> products = new List<Product>();

            foreach (var cartitem in item)
            {

                if (item != null)
                {

                    Product product = new Product();

                    product.ProductID = cartitem.ProductID;
                    product.ProductName = cartitem.ProductName;
                    product.Price = cartitem.Price;
                    product.Quantity = cartitem.Quantity;

                    products.Add(product);

                }

            }

            CartItems = products;

            return item;

        }

        public async Task<List<Product>> GetProducts(List<ProductDTO> productdto)
        {
            try
            {

                var call = await _client.PostAsJsonAsync("api/Cart/Quantity", productdto);
                var products = await call.Content.ReadFromJsonAsync<List<Product>>();

                return products;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }
    }
}
