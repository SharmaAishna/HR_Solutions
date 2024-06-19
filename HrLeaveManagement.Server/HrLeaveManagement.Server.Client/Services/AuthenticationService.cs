using Blazored.LocalStorage;
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        public AuthenticationService(IClient client, ILocalStorageService localStorage) :
            base(client, localStorage)
        {
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                    //Set claims in Blazor and login state
                    return true;
                }
                return false;
            }
            catch (Exception ) {
                return false;
            }

        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            // Remove claims in Blazor and invalidate login state
        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                FirstName = firstName,
                Email = email,
                Password = password
            };
            var response= await _client.RegisterAsync(registrationRequest);
           
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
