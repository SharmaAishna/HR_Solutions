﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public record GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationDTO>>
    {
    }
}
