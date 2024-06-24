using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages.LeaveTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
        [Inject]
        ILeaveTypeService leaveTypeService { get; set; }
        public string Message {  get;private set; }

        LeaveTypeVM LeaveTypeVM= new LeaveTypeVM();
        async Task CreateLeaveType()
        {
            var response = await leaveTypeService.CreateLeaveType(LeaveTypeVM);
            if (response.Success)
            {
                NavigationManager.NavigateTo("/leavetypes/");
            }
            Message = response.Message;
        }
    }
}