using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace HrLeaveManagement.Server.Client.Pages.LeaveTypes
{
    public partial class Details
    {
        [Inject]
        ILeaveTypeService _leaveTypeService {  get; set; }

        [Parameter]
        public int id {  get; set; }

        LeaveTypeVM LeaveTypesVM = new LeaveTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            LeaveTypesVM = await _leaveTypeService.GetLeaveTypeDetails(id);
        }
    }
}