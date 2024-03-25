using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Services
{
    public class LeaveAllocationService : BaseHttpService, IleaveAllocationService
    {
        public LeaveAllocationService(IClient client) : base(client)
        {
        }
    }
}
