using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Contracts.Email;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.UpdateLeaveType;
using HRLeaveManagementApplication.Logging;
using HRLeaveManagementApplication.Models.EmailModels;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.UpdateLeaveRequestCommand
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IEmailSender _emailSender;
        private readonly IAppLogger<UpdateLeaveRequestCommandHandler> _logger;

        public UpdateLeaveRequestCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveRequestRepository leaveRequestRepository,
            IEmailSender emailSender,
            IAppLogger<UpdateLeaveRequestCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request,
            CancellationToken cancellationToken)
        {
            //Validating incoming data
            var leaveRequest =await _leaveRequestRepository.GetByIdAsync(request.Id);
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(leaveRequest), request.Id);
            }

            var validator = new UpdateLeaveRequestCommandValidator(_leaveTypeRepository, _leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(LeaveRequest),
                    request.Id
                    );
                throw new BadRequestException("Invalid Leave Request", validationResult);
            }


            //convert to domain entity object
             _mapper.Map(request, leaveRequest);

            //add to database
            await _leaveRequestRepository.UpdateAsync(leaveRequest);
            try
            {

                //send confirmation email
                var email = new EmailMessage
                {
                    To = string.Empty,/*Get email from employee record*/
                    Body = $"Your leave request for {request.StartDate:D} to {request.EndDate} " + "$ has been updated successfully.",
                    Subject = "Leave Request Updated"
                };
                await _emailSender.SendEmail(email);

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
            }
            //return Unit value
            return Unit.Value;
        }
    }
}
