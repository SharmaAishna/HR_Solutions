﻿using HrLeaveManagement.Server.Contracts.Identity;
using HrLeaveManagement.Server.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeavemanagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        public Task<AuthResponse> Login(AuthRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}