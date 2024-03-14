using HRLeaveManagement.Domain;
using HRLeaveManagementApplication.Contracts.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagementApplication.Features.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)=>  _leaveTypeRepository = leaveTypeRepository;
        
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            
            //retrieve to domain entity object
            var leaveTypeToDelete = await _leaveTypeRepository.GetByIdAsync(request.Id);
            //verify that record exists.

            //remove from the database
            await _leaveTypeRepository.DeleteAsync(leaveTypeToDelete);
            //return record id
            return Unit.Value;
        }
    }
}
