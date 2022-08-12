using ECommerceApp.Shared;

namespace ECommerceApp.Client.Services
{
    public interface IUserController
    {

        List<User> users { get; set; }

        Task GetUsers();

        Task AddUser(User user);

    }
}
