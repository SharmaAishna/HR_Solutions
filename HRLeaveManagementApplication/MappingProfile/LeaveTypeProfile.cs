using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Features.Queries.GetAllLeaveTypes;
using HRLeaveManagementApplication.Features.Queries.GetLeaveTypeDetails;
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
        }
       
    }
}
