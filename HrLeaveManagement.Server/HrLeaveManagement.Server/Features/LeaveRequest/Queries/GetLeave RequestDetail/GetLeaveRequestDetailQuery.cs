using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeave_RequestDetail
{
    public record GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailsDTO>
    {
        public int Id { get; set; }
    }
}
