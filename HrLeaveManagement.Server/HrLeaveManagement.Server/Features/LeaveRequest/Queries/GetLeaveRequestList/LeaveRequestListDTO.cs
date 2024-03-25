using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class LeaveRequestListDTO
    {
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public DateTime DateRequested{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? Approved { get; set; }

    }
}
