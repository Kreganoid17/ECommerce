using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface IUsers
    {

        List<User> users { get; set; }

        bool Exists { get; set; }

        public Task<List<User>> GetUsers();

        public Task AddUser(UserDTO user);

    }
}
