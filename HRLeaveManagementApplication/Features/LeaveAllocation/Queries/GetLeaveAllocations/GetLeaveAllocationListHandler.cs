using AutoMapper;
using HRLeaveManagementApplication.Contracts.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationListQuery, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAlloactionRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAlloactionRepository, IMapper mapper)
        {
            _leaveAlloactionRepository = leaveAlloactionRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationListQuery request,
            CancellationToken cancellationToken)
        {
            //To Add later
            //-Get records for specific user

            //-Get allocations per employee

            var leaveAllocations = await _leaveAlloactionRepository.GetLeaveAllocationWithDetails();
            var allocations = _mapper.Map<List<LeaveAllocationDTO>>(leaveAllocations);
            return allocations;
        }
    }
}
