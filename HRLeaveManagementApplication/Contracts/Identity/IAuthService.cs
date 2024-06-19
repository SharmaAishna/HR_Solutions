using HRLeaveManagementApplication.Models.Identity;

namespace HRLeaveManagementApplication.Contracts.Identity
{
    public interface IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request);
        public Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
