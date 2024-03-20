using HRLeaveManagementApplication.Features.LeaveRequest.Shared;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
    }
   
}
