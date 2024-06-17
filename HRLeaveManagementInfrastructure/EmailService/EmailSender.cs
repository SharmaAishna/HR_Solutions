﻿using HrLeaveManagement.Server.Contracts.Email;
using HrLeaveManagement.Server.Models.EmailModels;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HRLeaveManagementInfrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }

        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };
            var message = MailHelper.CreateSingleEmail(from, to, email.Subject,
                email.Body, email.Body);
            var response = await client.SendEmailAsync(message);
            return response.IsSuccessStatusCode;

            //response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;

        }
    }
}
