using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages.LeaveTypes
{
    public partial class Edit
    {
        [Inject]
        ILeaveTypeService _leaveTypeService { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        LeaveTypeVM LeavesTypesVM = new LeaveTypeVM();
        protected async override Task OnParametersSetAsync()
        {
            LeavesTypesVM = await _leaveTypeService.GetLeaveTypeDetails(id);
        }

        async Task EditLeaveType()
        {
            var response = await _leaveTypeService.UpdateLeaveType(id, LeavesTypesVM);
            if (response.Success)
            {
                _navigationManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }









    }
}