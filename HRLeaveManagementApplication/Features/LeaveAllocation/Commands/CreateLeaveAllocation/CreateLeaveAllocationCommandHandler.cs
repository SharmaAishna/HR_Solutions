using AutoMapper;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Exceptions;

using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler :
        IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public CreateLeaveAllocationCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request,
            CancellationToken cancellationToken)
        {
            //Validating incoming data
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

            //Get Leave type for allocations
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);
            //Get Employees

            //Get Period

            //Assign Allocations
            var leaveAllocation = _mapper.Map<HRLeaveManagement.Domain.LeaveAllocation>(request);
            await _leaveAllocationRepository.CreateAsync(leaveAllocation);

            //return record id
            return Unit.Value;
        }
    }
}
