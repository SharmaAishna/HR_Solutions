using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRLeaveManagementPersistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(
               new LeaveType
               {
                   Id = 1,
                   Name = "Vacation",
                   DefaultDays = 10,
                   DateCreated = DateTime.Now,
                   DateModified = DateTime.Now
               });

            //other way of restricting the value in database at application level apart from fluentValidation
           // builder.Property(q=>q.Name).IsRequired().HasMaxLength(100);
        }
    }
}
