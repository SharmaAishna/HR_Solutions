using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Services
{
    public class LeaveTypeService : BaseHttpService, IleaveTypeService
    {
        public LeaveTypeService(IClient client) : base(client)
        {
        }
    }
}
