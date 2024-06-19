using HRLeavemanagement.Identity.DbContext;
using HRLeavemanagement.Identity.Models;
using HRLeavemanagement.Identity.Services;
using HRLeaveManagementApplication.Contracts.Identity;
using HRLeaveManagementApplication.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HRLeavemanagement.Identity
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            //Add JwtSettings
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
           //AddDbContext
            services.AddDbContext<HrLeaveManagementIdentityDbContext>(options =>

                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            
            //Add Identity Libraray
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<HrLeaveManagementIdentityDbContext>()
            .AddDefaultTokenProviders();

            //Add services ,new instances everytime services are called
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            //Add Authentication ,strongly typed Jwt Bearer
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //adding Jwt rules defining how bearer token should be evaluated and validated
                .AddJwtBearer(Rule =>
                {
                    Rule.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                        (configuration["JwtSettings:Key"]))

                    };

                });
            return services;
        }
    }
}
