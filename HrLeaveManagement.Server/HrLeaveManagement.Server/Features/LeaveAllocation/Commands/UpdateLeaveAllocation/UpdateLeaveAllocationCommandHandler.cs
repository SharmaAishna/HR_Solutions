using AutoMapper;
using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Exceptions;
using HrLeaveManagement.Server.Features.LeaveTypes.Commands.UpdateLeaveType;
using HrLeaveManagement.Server.Logging;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveAllocation.Commands.UpdateLeaveAllocation
{
    public class UpdateLeaveAllocationCommandHandler : 
        IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IAppLogger<UpdateLeaveAllocationCommandHandler> _logger;

        public UpdateLeaveAllocationCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            ILeaveAllocationRepository leaveAllocationRepository,
            IAppLogger<UpdateLeaveAllocationCommandHandler> logger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            //Validating incoming data
            var validator = new UpdateLeaveAllocationCommandValidator(_leaveTypeRepository,_leaveAllocationRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}",
                    nameof(LeaveAllocation),
                    request.Id
                    );
                throw new BadRequestException("Invalid Leave Allocation", validationResult);
            }
            //convert to domain entity object
            var leaveAllocation = await _leaveAllocationRepository.GetByIdAsync(request.Id);
            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation),
                    request.Id);
            }
            _mapper.Map(request, leaveAllocation);

            //add to database
            await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
            //return Unit value
            return Unit.Value;
        }
    }
}
