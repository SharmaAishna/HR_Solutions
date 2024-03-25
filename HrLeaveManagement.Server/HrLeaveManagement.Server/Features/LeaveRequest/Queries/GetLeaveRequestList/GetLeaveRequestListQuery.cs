using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public record GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDTO>>;
}
