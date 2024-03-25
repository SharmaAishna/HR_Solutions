using AutoMapper;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails;
using MediatR;

public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDetailsDTO>
{
    private readonly ILeaveAllocationRepository _leaveAlloactionRepository;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAlloactionRepository,IMapper mapper)
    {
        _leaveAlloactionRepository = leaveAlloactionRepository;
        _mapper = mapper;
    }
    public async Task<LeaveAllocationDetailsDTO> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAlloactionRepository.GetLeaveAllocationWithDetails(request.Id);
        return _mapper.Map<LeaveAllocationDetailsDTO>(leaveAllocation);
    }
}
