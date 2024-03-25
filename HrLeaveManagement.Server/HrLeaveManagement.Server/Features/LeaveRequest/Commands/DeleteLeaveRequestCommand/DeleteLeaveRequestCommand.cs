using HrLeaveManagement.Server.Features.LeaveTypes.Commands.DeleteLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.DeleteLeaveRequestCommand
{
    public class DeleteLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
