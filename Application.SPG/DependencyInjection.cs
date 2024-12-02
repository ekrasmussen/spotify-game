using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.SPG
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationSpg(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(StaticHandleAssembly)) ?? throw new SystemException(nameof(StaticHandleAssembly)));
            });

            return services;
        }
    }
}
