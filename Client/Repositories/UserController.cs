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
            await _client.PostAsJsonAsync("api/AddUser/", user);
        }

        public async Task GetUsers()
        {

            var Users = await _client.GetFromJsonAsync<List<User>>("api/AddUser");

            users = Users;

        }

        

    }
}
