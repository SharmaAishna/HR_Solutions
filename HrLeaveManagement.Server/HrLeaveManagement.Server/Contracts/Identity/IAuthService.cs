using HrLeaveManagement.Server.Models.Identity;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace HrLeaveManagement.Server.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request);
        public Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
