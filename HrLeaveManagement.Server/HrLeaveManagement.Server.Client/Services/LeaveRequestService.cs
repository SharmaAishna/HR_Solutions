﻿using Blazored.LocalStorage;
using HrLeaveManagement.Server.Client.Contracts;
using HrLeaveManagement.Server.Client.Services.Base;

namespace HrLeaveManagement.Server.Client.Services
{
    public class LeaveRequestService : BaseHttpService, ILeaveRequestService
    {
        public LeaveRequestService(IClient client, ILocalStorageService localStorageService) : base(client,localStorageService)
        {
        }
    }
}
