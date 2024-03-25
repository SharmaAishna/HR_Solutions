using FluentValidation;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Features.LeaveRequest.Shared;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.CreateLeaveRequestCommand
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
