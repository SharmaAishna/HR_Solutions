using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Services
{
    public class LeaveRequestService : BaseHttpService, IleaveRequestService
    {
        public LeaveRequestService(IClient client) : base(client)
        {
        }
    }
}
