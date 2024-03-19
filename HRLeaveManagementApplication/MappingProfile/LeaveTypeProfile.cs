using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.CreateLeaveType;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.UpdateLeaveType;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.MappingProfile
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
            //In current Buisness requirement, Didn't reverse map LeaveTypeDetailsDTO because it is readonly details.
            CreateMap<LeaveType,LeaveTypeDetailsDTO>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        }    
    }
}
