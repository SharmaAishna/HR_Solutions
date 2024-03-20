using FluentValidation;
using HRLeaveManagementApplication.Features.LeaveRequest.Commands.ChangeLeaveRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandValidator:AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidator()
        {
            RuleFor(p => p.Approved)
            .NotNull()
            .WithMessage("Approval status cannot be null");
        }
    }
}
