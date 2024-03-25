using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HRLeaveManagementPersistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagementPersistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {

        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequests = await _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                  .Include(x => x.LeaveType)
                  .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _context.LeaveRequests
                .Where(q => q.RequestingEmployeeId == userId)
                  .Include(q => q.LeaveType)
                  .ToListAsync();
            return leaveRequests;
        }
    }
}
