using ECommerceApp.Client.Services;
using ECommerceApp.Shared.DTO;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class MailController : IMailController
    {
        private readonly HttpClient _client;

        public MailController(HttpClient client)
        {

            _client = client;
     
        }

        public async Task SendMail(List<CartDTO> cartdto)
        {
            try
            {

                await _client.PostAsJsonAsync("api/Mail", cartdto);

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);
            
            }
        }
    }
}
