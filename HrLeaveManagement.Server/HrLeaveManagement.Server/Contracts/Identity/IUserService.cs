using HrLeaveManagement.Server.Models.Identity;

namespace HrLeaveManagement.Server.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
    }
}
