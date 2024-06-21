using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace HrLeaveManagement.Server.Client.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message {  get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }
        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }

        protected async Task HandleLogin()
        {
            if(await AuthenticationService.AuthenticateAsync(Model.Email,Model.Password))
            {
                NavigationManager.NavigateTo("home");
            }
            Message = "username/password combination unknown";

        }
    }
}