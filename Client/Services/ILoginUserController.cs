using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface ILoginUserController
    {

        public bool IsValid { get; set; }

        Task IsValidUser(LoginDTO login);

    }
}
