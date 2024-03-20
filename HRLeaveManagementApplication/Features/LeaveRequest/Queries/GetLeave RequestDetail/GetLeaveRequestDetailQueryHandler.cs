using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Queries.GetLeave_RequestDetail
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
