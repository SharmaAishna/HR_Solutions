using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDTO>>;

}
