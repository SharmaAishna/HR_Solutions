﻿using HRLeaveManagement.Domain;
using HrLeaveManagement.Server.Contracts.DataAccess;
using HrLeaveManagement.Server.Exceptions;
using MediatR;

namespace HrLeaveManagement.Server.Features.LeaveRequest.Commands.DeleteLeaveRequestCommand
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository) => _leaveRequestRepository = leaveRequestRepository;

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            //retrieve to domain entity object
            var leaveRequestToDelete = await _leaveRequestRepository.GetByIdAsync(request.Id);

            //verify that record exists.
            if (leaveRequestToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }

            //remove from the database
            await _leaveRequestRepository.DeleteAsync(leaveRequestToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
