using ECommerceApp.Shared.DTO;

namespace ECommerceApp.Client.Services
{
    public interface IMailController
    {

        Task SendMail(List<CartDTO> cratdto);

    }
}
