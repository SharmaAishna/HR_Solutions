using FluentValidation;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Features.LeaveRequest.Shared;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.UpdateLeaveRequestCommand
{
    public class UpdateLeaveRequestCommandValidator : AbstractValidator<UpdateLeaveRequestCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public UpdateLeaveRequestCommandValidator(ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;

            Include(new BaseLeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(LeaveRequestMustExist)
                .WithMessage("{PropertyName} must be present");

        }
        private async Task<bool> LeaveRequestMustExist(int id, CancellationToken token)
        {
            var leaveType = await _leaveRequestRepository.GetByIdAsync(id);
            return leaveType != null;
        }

    }
}
