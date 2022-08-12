using ECommerceApp.Shared;

namespace ECommerceApp.Server.Services
{
    public interface IUsers
    {

        List<User> users { get; set; }

        public Task<List<User>> GetUsers();

        public Task AddUser(User user);

    }
}
