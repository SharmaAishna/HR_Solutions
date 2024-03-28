using HrLeaveManagement.Server.Models.Identity;

namespace HrLeaveManagement.Server.Contracts.Identity
{
    public interface IUserService
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(string userId);
    }
}
