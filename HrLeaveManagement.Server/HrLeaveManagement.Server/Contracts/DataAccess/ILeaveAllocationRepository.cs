using HRLeaveManagement.Domain;

namespace HrLeaveManagement.Server.Contracts.DataAccess
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id);
        public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails();
        public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId);
        public Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        public Task AddAllocations(List<LeaveAllocation> allocations);
        public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);
    }
}
