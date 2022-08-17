using ECommerceApp.Server.Services;
using ECommerceApp.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {

        private readonly ILoginUser _Iuser;

        public LoginUserController(ILoginUser Iuser)
        {
            _Iuser = Iuser;
        }

        [HttpPost]
        public async Task<AuthDTO> IsValidUser(LoginDTO login) {

            try
            {

                var user = await _Iuser.IsValidUser(login);

                if (user == true)
                {

                    return await _Iuser.SetUser(login);

                }
                else { 
                
                    return new AuthDTO();   
                
                }

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

    }
}
