using ECommerceApp.Client.Services;
using ECommerceApp.Shared.DTO;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class OrderController : IOrderController
    {

        private readonly HttpClient _client;

        public OrderController(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<OrderDTO>> GetOrders(int userid)
        {
            try
            {

                var orders =  await _client.GetFromJsonAsync<List<OrderDTO>>($"api/Order/{userid}");

                return orders;


            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        }


        public async  Task<OrderDetailsDTO> GetOrder(int orderid)
        {
            try
            {

                var order = await _client.GetFromJsonAsync<OrderDetailsDTO>($"api/Order/GetOrder/{orderid}");

                return order;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }


        }

    }
}
