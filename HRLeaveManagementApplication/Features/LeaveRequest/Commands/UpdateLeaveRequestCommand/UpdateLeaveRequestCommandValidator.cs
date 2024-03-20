using FluentValidation;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Features.LeaveRequest.Shared;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.UpdateLeaveRequestCommand
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
