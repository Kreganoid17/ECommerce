using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Server.Services
{
    public interface IMail
    {

        void SendMail(List<CartDTO> cartdto);

    }
}
