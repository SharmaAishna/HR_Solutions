﻿using AutoMapper;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Contracts.Email;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveRequest.Commands.CreateLeaveRequestCommand;
using HRLeaveManagementApplication.Logging;
using HRLeaveManagementApplication.Models.EmailModels;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;

        public CancelLeaveRequestCommandHandler(
            ILeaveRequestRepository leaveRequestRepository,
            IEmailSender emailSender,
            IAppLogger<CreateLeaveRequestCommandHandler> logger)
        {
            
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _logger = logger;
        }
        public async Task<Unit> Handle(CancelLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(leaveRequest),request.Id);
            }
            leaveRequest.Cancelled = true;

            //if already approved,Re-evaluate the employee's allocations for the leave type

            //send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/*Get email from employee record*/
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate:D} " + "$ has been cancelled successfully.",
                    Subject = "Leave Request Cancelled"
                };
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }

            return Unit.Value;
        }
    }
}
