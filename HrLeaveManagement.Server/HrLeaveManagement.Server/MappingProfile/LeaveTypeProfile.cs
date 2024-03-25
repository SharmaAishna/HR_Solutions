using AutoMapper;
using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Features.LeaveTypes.Commands.CreateLeaveType;
using HrLeaveManagement.Server.Features.LeaveTypes.Commands.UpdateLeaveType;
using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server.MappingProfile
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
