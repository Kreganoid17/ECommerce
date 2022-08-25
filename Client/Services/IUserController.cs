using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface IUserController
    {

        List<User> users { get; set; }

        bool UserExists { get; set; }

        Task GetUsers();

        Task AddUser(UserDTO user);

    }
}
