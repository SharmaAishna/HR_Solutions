using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocations;

namespace HRLeaveManagementApplication.MappingProfile
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDTO, LeaveAllocation>().ReverseMap();
            //In current Buisness requirement, Didn't reverse map LeaveTypeDetailsDTO because it is readonly details.
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDTO>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        //    CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }

    }
}
