using AutoMapper;
using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HrLeaveManagement.Server.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocations;

namespace HrLeaveManagement.Server.MappingProfile
{
    public class LeaveAllocationProfile : Profile
    {
        public LeaveAllocationProfile()
        {
            CreateMap<LeaveAllocationDTO, LeaveAllocation>().ReverseMap();
            //In current Buisness requirement, Didn't reverse map LeaveTypeDetailsDTO because it is readonly details.
            CreateMap<LeaveAllocation, LeaveAllocationDetailsDTO>();
            CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
            CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
        }

    }
}
