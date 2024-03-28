using HrLeaveManagement.Server.Models.EmailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Contracts.Email
{
    public interface IEmailSender
    {
        public Task<bool> SendEmail(EmailMessage email);
    }
}
