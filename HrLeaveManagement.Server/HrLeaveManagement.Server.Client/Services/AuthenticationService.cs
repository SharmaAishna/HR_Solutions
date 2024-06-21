﻿using Blazored.LocalStorage;
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Providers;
using HrLeaveManagement.Server.Client.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HrLeaveManagement.Server.Client.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IClient client, 
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) :
            base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                AuthRequest authenticationRequest = new AuthRequest()
                {
                    Email = email,
                    Password = password
                };

                var authenticationResponse = await _client.LoginAsync(authenticationRequest);
                if (authenticationResponse.Token != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                    //Set claims in Blazor and login state
                    await ((ApiAuthenticationStateProvider)
                        _authenticationStateProvider).LoggedIn();
                    return true;
                }
                return false;
            }
            catch (Exception )
            {
                return false;
            }

        }

        public async Task Logout()
        {
            // await _localStorage.RemoveItemAsync("token");
            // Remove claims in Blazor and invalidate login state
            await ((ApiAuthenticationStateProvider)
                           _authenticationStateProvider).LoggedOut();

        }

        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                FirstName = firstName,
                LastName= lastName,
                UserName=userName,
                Email = email,
                Password = password
            };
            var response= await _client.RegisterAsync(registrationRequest);
           
            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }
    }
}
