using AutoMapper;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HRLeaveManagementApplication.Logging;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveRequest.Queries.GetLeaveRequestList
{
    public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestListQuery, List<LeaveRequestListDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IAppLogger<GetLeaveTypesQueryHandler> _logger;

        public GetLeaveRequestQueryHandler(IMapper mapper,
            ILeaveRequestRepository leaveRequestRepository,
            IAppLogger<GetLeaveTypesQueryHandler> logger)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _logger = logger;
        }


        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestListQuery request, CancellationToken cancellationToken)
        {
            //Check if it is logged in employee

            //Query the database
            var leaveRequest = await _leaveRequestRepository.GetAllAsync();

            //convert data objects to DTO objects
            var data = _mapper.Map<List<LeaveRequestListDTO>>(leaveRequest);

            //Fill requests with employee information

            //return list of DTO object
            _logger.LogInformation("Leave Request were retrieved successfully");
            return data;
        }
    }
}
