using MediatR;

namespace HRLeaveManagementApplication.Features.LeaveTypes.Commands.UpdateLeaveType
{
    //Whenever operation don't expect a return type use Unit datatype
    public class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
    }
}
