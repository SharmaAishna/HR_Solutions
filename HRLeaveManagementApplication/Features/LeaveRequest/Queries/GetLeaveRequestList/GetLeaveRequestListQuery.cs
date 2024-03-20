using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public record GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDTO>>;
}
