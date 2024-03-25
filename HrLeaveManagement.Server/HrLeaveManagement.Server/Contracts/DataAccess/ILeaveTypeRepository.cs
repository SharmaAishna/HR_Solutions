using HRLeaveManagement.Domain;

namespace HrLeaveManagement.Server.Contracts.DataAccess
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    }
}
