using AutoMapper;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Contracts.Email;
using HrLeaveManagement.Server.Exceptions;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.ChangeLeaveRequest;
using HrLeaveManagement.Server.Features.LeaveRequest.Commands.CreateLeaveRequestCommand;
using HrLeaveManagement.Server.Logging;
using HrLeaveManagement.Server.Models.EmailModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<ChangeLeaveRequestApprovalCommandHandler> _logger;

        public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper,
            IEmailSender emailSender,
            ILeaveRequestRepository leaveRequestRepository,
            ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<ChangeLeaveRequestApprovalCommandHandler> logger)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest= await _leaveRequestRepository.GetByIdAsync(request.Id);   
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }
            leaveRequest.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            //if request is approved, get and update the employee's allocation

            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/*Get email from employee record*/
                    Body = $"The approval status for your leave request for {request.StartDate:D} to {request.EndDate} " + "$ has been updated.",
                    Subject = "Leave Request Approval Status Updated"
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
