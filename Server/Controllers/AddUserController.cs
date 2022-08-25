using ECommerceApp.Client.Services;
using ECommerceApp.Server.Services;
using ECommerceApp.Shared;
using ECommerceApp.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserController : ControllerBase
    {
        private readonly IUsers _Iuser;

        public AddUserController(IUsers Iuser) {
            
            _Iuser = Iuser;

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers() {

            try
            {

                return await _Iuser.GetUsers();

            }
            catch (Exception ex) { 
            
                throw new Exception(ex.Message);
            
            }
        
        }

        [HttpPost]
        public async Task<bool> AddUser(UserDTO user) {

            try
            {

                await _Iuser.AddUser(user);

                return _Iuser.Exists;

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
        
        }

    }
}
