using HRLeaveManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDTO : BaseEntity
    {
      
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
