using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Contracts
{
    public interface ILeaveTypeService
    {
        public Task<List<LeaveTypeVM>> GetLeaveTypes();
        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id);
        public Task<Response<Guid>> CreateLeaveType(LeaveTypeVM leaveType);
        public Task<Response<Guid>> UpdateLeaveType(int id, LeaveTypeVM leaveType);
        public Task<Response<Guid>> DeleteLeaveType(int id);
    }
}
