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

        //Come Back to this to add cart details to db
        public async Task AddCartToDB(List<CartDTO> cartdto)
        {

            for (int i = 0; i < cartdto.Count; i++)
            {

                User user = _context.Users.SingleOrDefault(x => x.ID == cartdto[i].UserID);

                Cart cart = new Cart();

                cart.user = user;

                cart.CartItems = cartdto[i].ProductID.ToString();

                cart.CartQauntity = cartdto[i].Quantity.ToString();

                _context.cart.Add(cart);

                await _context.SaveChangesAsync();

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
    }
}
