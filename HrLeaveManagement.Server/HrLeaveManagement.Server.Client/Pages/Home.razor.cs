
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Providers;
using HrLeaveManagement.Server.Client.ViewModels.LeaveTypes;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Runtime.CompilerServices;

namespace HrLeaveManagement.Server.Client.Pages
{
    public partial class Home
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
       
        protected async override Task OnInitializedAsync()
        {
            await((ApiAuthenticationStateProvider)
                AuthenticationStateProvider).GetAuthenticationStateAsync();
        }
        protected void GoToLogin()
        {
            NavigationManager.NavigateTo("login/");
        }
        protected void GoToRegister()
        {
            NavigationManager.NavigateTo("register/");
        }
        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}