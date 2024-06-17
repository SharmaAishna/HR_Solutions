using HRLeaveManagementApplication.Models.EmailModels;

namespace HRLeaveManagementApplication.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}
