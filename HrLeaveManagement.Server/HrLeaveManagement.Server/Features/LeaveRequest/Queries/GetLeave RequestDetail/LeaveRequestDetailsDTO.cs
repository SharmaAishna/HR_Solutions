using HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeaveRequestList;
using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeave_RequestDetail
{
    public class LeaveRequestDetailsDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RequestingEmployeeId { get; set; }
        public LeaveTypeDTO LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
        public DateTime? DateActioned { get; set;}
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }

}
