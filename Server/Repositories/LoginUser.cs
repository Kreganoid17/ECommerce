using Blazored.LocalStorage;
using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.Repositories
{
    public class LoginUser : ILoginUser
    {

        private readonly DataContext _context;

        public LoginUser(DataContext context)
        {
            _context = context;
      
        }

        public async Task<bool> IsValidUser(LoginDTO login)
        {
            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);

                if (user == null)
                {

                    return false;

                }
                else
                {

                    return true;

                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);


            }
        }

        public async Task<AuthDTO> SetUser(LoginDTO login) {

            try
            {

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == login.Password);

                AuthDTO authdto = new AuthDTO();

                authdto.Username = user.Username;
                authdto.Token = "Some Secret Token";

                return authdto;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }
    }
}
