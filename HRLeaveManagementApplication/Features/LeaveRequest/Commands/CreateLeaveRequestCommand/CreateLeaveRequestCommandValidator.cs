using FluentValidation;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Features.LeaveRequest.Shared;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.CreateLeaveRequestCommand
{
    public class CreateLeaveRequestCommandValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
             _leaveTypeRepository = leaveTypeRepository;
            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));
        }

    }
}
