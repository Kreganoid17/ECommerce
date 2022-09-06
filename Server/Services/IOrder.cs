using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface IOrder
    {

        public List<OrderDTO> GetOrders(int userid);

        public OrderDetailsDTO GetOrder(int orderid);

    }
}
