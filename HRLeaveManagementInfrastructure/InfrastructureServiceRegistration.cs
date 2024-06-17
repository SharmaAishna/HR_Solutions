using HrLeaveManagement.Server.Contracts.Email;
using HrLeaveManagement.Server.Logging;
using HrLeaveManagement.Server.Models.EmailModels;
using HRLeaveManagementInfrastructure.EmailService;
using HRLeaveManagementInfrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRLeaveManagementInfrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection
            services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
