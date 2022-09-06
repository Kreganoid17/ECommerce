using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Repositories
{
    public class CartFunctions : ICart
    {
        private readonly DataContext _context;

        public CartFunctions(DataContext context)
        {
            _context = context;
        }

        public async Task AddCartToDB(CartDBDTO cart)
        {

            try {

                char delim = ',';

                List<CartDTO> cartdto = cart.cart;

                var userid = cart.userid;

                var cartuser = _context.cart.SingleOrDefault(x => x.user.ID == userid);

                if (cartuser == null)
                {

                    if (cartdto.Count > 0) {

                        User user = new User();

                        user = _context.Users.SingleOrDefault(x => x.ID == userid);

                        Cart cartobj = new Cart();

                        cartobj.CartItems = String.Join(delim, cartdto.Select(x => x.ProductID));
                        cartobj.CartQauntity = String.Join(delim, cartdto.Select(x => x.Quantity));
                        cartobj.Price = String.Join(delim, cartdto.Select(x => x.Price));
                        cartobj.user = user;

                        _context.cart.Add(cartobj);

                        _context.SaveChanges();

                    }

                }
                else if (cartuser != null) {


                    if (cartdto.Count > 0)
                    {

                        cartuser.CartItems = String.Join(delim, cartdto.Select(x => x.ProductID));
                        cartuser.CartQauntity = String.Join(delim, cartdto.Select(x => x.Quantity));
                        cartuser.Price = String.Join(delim, cartdto.Select(x => x.Price));

                        _context.SaveChanges();

                    }
                    else if (cartdto.Count == 0) {

                        _context.cart.Remove(cartuser);

                        _context.SaveChanges();

                    }


                }
               

            }catch(Exception ex) {

                throw new Exception(ex.Message);
            
            }


        }

        public async Task AddToCart(Cart cart)
        {

            try
            {
                
                if (cart.Id == 0)
                {

                    var usercart = _context.cart.SingleOrDefault(x => x.Id == cart.Id);

                    usercart.CartItems = cart.CartItems;
                    usercart.CartQauntity = cart.CartQauntity;
                    usercart.Price = cart.Price;

                }
                else{

                    _context.cart.Add(cart);

                }

                await _context.SaveChangesAsync();

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }

        public async Task<List<Product>> GetProducts(List<ProductDTO> productdto)
        {

            try
            {

                List<Product> products = new List<Product>();   

                foreach (var item in productdto) {

                    var product = await _context.Products.FindAsync(item.ProductID);

                    products.Add(product);

                }


                return products;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);            
            }

        }

        public async Task<List<CartDTO>> LoadCart(int userid)
        {
            try
            {
                var usercart = _context.cart.SingleOrDefault(x => x.user.ID == userid);

                if (usercart == null)
                {

                    return new List<CartDTO>();

                }
                else {

                    List<CartDTO> cartdto = new List<CartDTO>();

                    List<int> products = usercart.CartItems.Split(',').ToList().ConvertAll(int.Parse);
                    List<int> quantity = usercart.CartQauntity.Split(',').ToList().ConvertAll(int.Parse);

                    List<Product> product = new List<Product>();

                    for (int i = 0; i < products.Count; i++)
                    {

                        Product prod = new Product();

                        var prd = _context.Products.SingleOrDefault(x => x.ProductID == products[i]);

                        prod.ProductID = prd.ProductID;
                        prod.ProductName = prd.ProductName;
                        prod.Quantity = quantity[i];
                        prod.Price = prd.Price;

                        product.Add(prod);

                    }

                    for (int i = 0; i < product.Count; i++)
                    {

                        CartDTO Cartdto = new CartDTO();

                        Cartdto.ProductID = product[i].ProductID;
                        Cartdto.ProductName = product[i].ProductName;
                        Cartdto.Quantity = product[i].Quantity;
                        Cartdto.Price = product[i].Price;

                        cartdto.Add(Cartdto);

                    }

                    return cartdto;

                }

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }
    }
}
