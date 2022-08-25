using Blazored.LocalStorage;
using ECommerceApp.Client.Services;
using ECommerceApp.Shared.DTO;
using System.Net.Http.Json;

namespace ECommerceApp.Client.Repositories
{
    public class LoginUserController : ILoginUserController
    {

        private readonly HttpClient _client;
        private readonly ILocalStorageService _localstorage;

        public LoginUserController(HttpClient client, ILocalStorageService localstorage)
        {
            _client = client;
            _localstorage = localstorage;
        }

        public bool IsValid { get; set; }

        public async Task IsValidUser(LoginDTO login)
        {

            try
            {

                var call = await _client.PostAsJsonAsync("api/LoginUser", login);
                var authdto = await call.Content.ReadFromJsonAsync<AuthDTO>();

                if (authdto.Username != null && authdto.Token != null)
                {

                    await LoginUser(authdto);
                    IsValid = true;

                }
                else
                {


                    IsValid = false;

                }

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }
 
        }

        private async Task LoginUser(AuthDTO authdto) {

            try
            {

                await _localstorage.SetItemAsync("User", authdto);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }
    }
}
