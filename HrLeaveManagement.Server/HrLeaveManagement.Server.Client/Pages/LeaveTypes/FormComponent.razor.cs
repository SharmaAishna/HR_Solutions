using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages.LeaveTypes
{
    public partial class FormComponent
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public LeaveTypeVM FormLeavesTypes { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; } 

    }
}