using Microsoft.AspNetCore.Components.Authorization;

namespace HrLeaveManagement.Server.Client.Providers
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
