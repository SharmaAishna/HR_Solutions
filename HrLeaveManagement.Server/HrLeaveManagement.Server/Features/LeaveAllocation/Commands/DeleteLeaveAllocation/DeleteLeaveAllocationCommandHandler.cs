using AutoMapper;
using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Exceptions;
using HrLeaveManagement.Server.Features.LeaveTypes.Commands.DeleteLeaveType;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {

            //retrieve to domain entity object
            var leaveAllocationToDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);

            //verify that record exists.
            if (leaveAllocationToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            }

            //remove from the database
            await _leaveAllocationRepository.DeleteAsync(leaveAllocationToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
