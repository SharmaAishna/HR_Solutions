﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDTO>>;

}
