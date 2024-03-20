using HRLeaveManagementApplication.Features.LeaveRequest.Shared;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
