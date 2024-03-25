using AutoMapper;
using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Exceptions;
using HrLeaveManagement.Server.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Queries.GetLeave_RequestDetail
{
    public class GetLeaveRequestDetailQueryHandler : IRequestHandler
        <GetLeaveRequestDetailQuery,
        LeaveRequestDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public GetLeaveRequestDetailQueryHandler(IMapper mapper,
            ILeaveRequestRepository leaveRequestRepository)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<LeaveRequestDetailsDTO> Handle(GetLeaveRequestDetailQuery request,
            CancellationToken cancellationToken)
        {
            //Query the database
            var leaveRequest = _mapper.Map < LeaveRequestDetailsDTO > (
                await _leaveRequestRepository.GetByIdAsync(request.Id));

            //verify that record exists.
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }
           //Add Employee Details as needed
            return leaveRequest;
        }
    }
}
