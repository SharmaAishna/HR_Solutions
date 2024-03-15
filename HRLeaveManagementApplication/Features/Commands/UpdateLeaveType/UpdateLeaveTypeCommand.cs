﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.Commands.UpdateLeaveType
{
    //Whenever operation don't expect a return type use Unit datatype
    public class UpdateLeaveTypeCommand:IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}