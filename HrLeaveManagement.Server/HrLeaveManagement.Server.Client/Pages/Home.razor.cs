using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Models.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages
{
    public partial class Home
    {
        [Inject] public NavigationManager _NavigationManager { get; set; }
        [Inject] public ILeaveTypeService LeaveTypeService { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<LeaveTypeVM> LeaveTypes { get; private set; }
        protected void CreateLeaveType()
        {
            _NavigationManager.NavigateTo("/leavetypes/create/");
        }
        protected void AllocateLeaveType(int id)
        {
            //Use Leave Allocation Service
        }
        protected void DetailsLeaveType(int id)
        {
            _NavigationManager.NavigateTo($"/leavetypes/details/{id}");
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
            _NavigationManager.NavigateTo($"/leavetypes/edit/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            LeaveTypes = await LeaveTypeService.GetLeaveTypes();
        }
    }
}