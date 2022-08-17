using ECommerceApp.Client.Services;
using ECommerceApp.Shared;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class UserController : IUserController
    {
        private readonly HttpClient _client;

        public UserController(HttpClient client)
        {
            _client = client;
        }

        public List<User> users { get; set; }

        public async Task AddUser(User user)
        {
            try
            {

                await _client.PostAsJsonAsync("api/AddUser/", user);

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);
            
            }
        }

        public async Task GetUsers()
        {

            try
            {

                var Users = await _client.GetFromJsonAsync<List<User>>("api/AddUser");

                users = Users;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }

    }
}
