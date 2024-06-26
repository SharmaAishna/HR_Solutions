﻿using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HRLeaveManagementPersistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagementPersistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {

        }
       
        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _context.LeaveTypes.AnyAsync(t => t.Name == name) == false;
        }
    }
}
