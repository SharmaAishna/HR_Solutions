using HRLeaveManagement.Domain;

namespace HRLeaveManagementApplication.Contracts.DataAccess
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
