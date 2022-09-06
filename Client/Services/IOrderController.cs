using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface IOrderController
    {

        public Task<List<OrderDTO>> GetOrders(int userid);

        public Task<OrderDetailsDTO> GetOrder(int orderid);

    }
}
