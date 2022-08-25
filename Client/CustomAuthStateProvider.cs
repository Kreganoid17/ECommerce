using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace ECommerceApp.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localstorage;

        public CustomAuthStateProvider(ILocalStorageService localstorage)
        {
            _localstorage = localstorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            try
            {

                var state = new AuthenticationState(new ClaimsPrincipal());

                string username = await _localstorage.GetItemAsStringAsync("User");

                if (!string.IsNullOrEmpty(username))
                {

                    var claimsprincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>

                    {

                        new Claim(ClaimTypes.Name, username)

                    }, "test authentication"

                        ));

                    state = new AuthenticationState(claimsprincipal);


                }

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return await Task.FromResult(state);

            }
            catch (Exception ex) {

                throw new Exception(ex.Message);
            
            }

        }
    }
}
