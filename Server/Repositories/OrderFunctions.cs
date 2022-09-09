using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.Repositories
{
    public class OrderFunctions : IOrder
    {

        private readonly DataContext _context;

        public OrderFunctions(DataContext context)
        {
            _context = context;
        }

        public List<OrderDTO> GetOrders(int userid)
        {
            string delim = ",";

            try
            {

                List<OrderDTO> result = new List<OrderDTO>();

                SqlParameter Userid = new SqlParameter("@userid", userid);

                var orders = _context.orders.FromSqlRaw("dbo.GetOrders @userid", Userid).AsEnumerable().ToList();

                foreach (var order in orders)
                {

                    int[] products = Array.ConvertAll(order.Products.Split(delim), s => int.Parse(s));
                    int[] quantity = Array.ConvertAll(order.Quantities.Split(delim), s => int.Parse(s));
                    float[] prices = Array.ConvertAll(order.Prices.Split(delim), s => float.Parse(s));

                    string Products = "";

                    foreach (var item in products) {

                        var product = _context.Products.Find(item);

                        Products += product.ProductName + ", ";
                    
                    }

                    OrderDTO dodto = new OrderDTO();

                    dodto.ID = order.ID;
                    dodto.orderno = order.OrderNo;
                    dodto.orderid = products.ToList();
                    dodto.orderproducts = Products;
                    dodto.quantities = quantity.ToList();
                    dodto.prices = prices.ToList();
                    dodto.orderdate = order.date;

                    result.Add(dodto);

                }

                return result;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);

            }

        }

        public OrderDetailsDTO GetOrder(int orderid)
        {
            try
            {

                string delim = ",";

                OrderDetailsDTO oddto = new OrderDetailsDTO();

                List<string> orderproducts = new List<string>();

                SqlParameter Orderid = new SqlParameter("@orderid", orderid);

                var order = _context.orders.FromSqlRaw("dbo.GetOrder @orderid", Orderid).AsEnumerable().ToList();

                foreach (var item in order) {

                    int[] products = Array.ConvertAll(item.Products.Split(delim), s => int.Parse(s));
                    int[] quantity = Array.ConvertAll(item.Quantities.Split(delim), s => int.Parse(s));
                    float[] prices = Array.ConvertAll(item.Prices.Split(delim), s => float.Parse(s));


                    foreach (var prod in products)
                    {

                        var product = _context.Products.Find(prod);

                        orderproducts.Add(product.ProductName);

                    }

                    oddto.orderno = item.OrderNo;
                    oddto.orderproducts = orderproducts;
                    oddto.quantities = quantity.ToList();
                    oddto.prices = prices.ToList();
                    oddto.orderdate = item.date;

                }

                return oddto;

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);

            }
        }
    }
}
