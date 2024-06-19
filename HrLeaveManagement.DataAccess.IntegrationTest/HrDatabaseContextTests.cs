using HRLeaveManagement.Domain;
using HRLeaveManagementPersistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace HrLeaveManagement.DataAccess.IntegrationTest
{
    public class HrDatabaseContextTests
    {
        private readonly HrDatabaseContext _hrDatabaseContext;

        public HrDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
          
            _hrDatabaseContext = new HrDatabaseContext(dbOptions);
        }
        [Fact]
        public async Task Save_SetDateCreatedValue()
        {
            //Arrange
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert
            leaveType.DateCreated.ShouldNotBeNull();
        }
        [Fact]
        public async Task Save_SetDateModifiedValue()
        {
            var leaveType = new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            };

            //Act
            await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
            await _hrDatabaseContext.SaveChangesAsync();

            //Assert
            leaveType.DateModified.ShouldNotBeNull();
        }
    }
}