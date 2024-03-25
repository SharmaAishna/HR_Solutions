using AutoMapper;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Contracts.Email;
using HrLeaveManagement.Server.Exceptions;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.CreateLeaveRequestCommand;
using HrLeaveManagement.Server.Logging;
using HrLeaveManagement.Server.Models.EmailModels;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CanceLeaveRequestCommandHandler : IRequestHandler<CancelLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;

        public CanceLeaveRequestCommandHandler(
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
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate} " + "$ has been cancelled successfully.",
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
