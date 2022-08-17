using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface ILoginUser
    {

        public Task<bool> IsValidUser(LoginDTO login);

        public Task<AuthDTO> SetUser(LoginDTO login);

    }
}
