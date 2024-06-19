
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages
{
    public partial class Home
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public ILeaveTypeService LeaveTypeService { get; set; } 
        public string Message { get; set; } = string.Empty;
        public List<LeaveTypeVM> LeaveTypes { get; private set; } 
        protected void CreateLeaveType()
        {
            NavigationManager.NavigateTo("/leavetypes/create/");
        }
        protected void AllocateLeaveType(int id)
        {
            //Use Leave Allocation Service
        }
        protected void DetailsLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/details/{id}");
        }
        protected async Task DeleteLeaveType(int id)
        {
            var response = await LeaveTypeService.DeleteLeaveType(id);
            if (response.Success)
            {
                StateHasChanged();
            }
            else
            {
                Message = response.Message;
            }
        }
        protected void EditLeaveType(int id)
        {
            NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            StateHasChanged();
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
            StateHasChanged();
        }
    }
}