using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public record GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDetailsDTO>
    {
        public int Id { get; set; }
    }
   
}
