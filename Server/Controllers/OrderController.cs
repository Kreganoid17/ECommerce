using ECommerceApp.Server.Services;
using ECommerceApp.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpGet("{userid}")]
        public List<OrderDTO> GetOrders(int userid) {

            try
            {

                return _order.GetOrders(userid);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

        [HttpGet("GetOrder/{orderid}")]
        public OrderDetailsDTO GetOrder(int orderid) {

            try
            {

                return _order.GetOrder(orderid);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }


    }
}
