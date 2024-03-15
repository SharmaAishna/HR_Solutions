using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler
        <GetLeaveTypeDetailsQuery,
        LeaveTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypeDetailsQuery request,
            CancellationToken cancellationToken)
        {
            //Query the database
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //verify that record exists.
            if (leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
            //Convert data objects to DTOs
            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveType);
            //return data objects
            return data;
        }
    }
}
