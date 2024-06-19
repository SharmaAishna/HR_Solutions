using HRLeaveManagementApplication.Models.Identity;

namespace HRLeaveManagementApplication.Contracts.Identity
{
    public interface IUserService
    {
        public Task<List<Employee>> GetEmployees();
        public Task<Employee> GetEmployee(string userId);
    }
}
