using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Contracts.Email;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveRequest.Commands.UpdateLeaveRequestCommand;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.CreateLeaveType;
using HRLeaveManagementApplication.Logging;
using HRLeaveManagementApplication.Models.EmailModels;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.CreateLeaveRequestCommand
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<CreateLeaveRequestCommandHandler> _logger;

        public CreateLeaveRequestCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository,
            IEmailSender emailSender,
            IAppLogger<CreateLeaveRequestCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _logger = logger;
        }
        public async Task<Unit> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            //Validating incoming data
            var validator = new CreateLeaveRequestCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Request", validationResult);

            //Get requesting employee's id

            //check on employee's allocation

            //If allocations aren't enough return validation error with message

            //Create Leave Request
            var leaveRequest = _mapper.Map<HRLeaveManagement.Domain.LeaveRequest>(request);

            //add to database
            await _leaveRequestRepository.CreateAsync(leaveRequest);

            //send confirmation email
            try
            {
                var email = new EmailMessage
                {
                    To = string.Empty,/*Get email from employee record*/
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate} " + "$ has been submitted successfully.",
                    Subject = "Leave Request Submitted"
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
