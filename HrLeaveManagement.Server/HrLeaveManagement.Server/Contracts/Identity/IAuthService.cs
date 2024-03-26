using HrLeaveManagement.Server.Models.Identity;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace HrLeaveManagement.Server.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
