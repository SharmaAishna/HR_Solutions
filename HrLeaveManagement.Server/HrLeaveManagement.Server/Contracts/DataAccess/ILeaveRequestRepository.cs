using HRLeaveManagement.Domain;

namespace HrLeaveManagement.Server.Contracts.DataAccess
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        public Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
        public Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);
    }
}
