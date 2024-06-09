using HRLeaveManagement.Domain.Common;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class LeaveTypeDTO : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
