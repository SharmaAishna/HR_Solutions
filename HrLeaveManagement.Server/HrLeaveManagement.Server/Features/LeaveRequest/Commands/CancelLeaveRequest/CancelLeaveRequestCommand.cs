using HrLeaveManagement.Server.Features.LeaveRequest.Shared;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.CancelLeaveRequest
{
    public class CancelLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
