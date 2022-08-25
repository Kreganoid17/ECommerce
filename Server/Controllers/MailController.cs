using ECommerceApp.Server.Services;
using ECommerceApp.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {

        private readonly IMail _mail;

        public MailController(IMail mail)
        {
            _mail = mail;
        }

        [HttpPost]
        public void SendEmail(List<CartDTO> cartdto)
        {

            try
            {

                _mail.SendMail(cartdto);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }

        }

    }
}
