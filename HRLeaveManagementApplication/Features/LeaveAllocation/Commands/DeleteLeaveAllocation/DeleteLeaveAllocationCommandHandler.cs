using AutoMapper;
using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using HRLeaveManagementApplication.Exceptions;
using HRLeaveManagementApplication.Features.LeaveTypes.Commands.DeleteLeaveType;
using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
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
