using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HrLeaveManagement.Server
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(config=>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;

        }
    }
}
