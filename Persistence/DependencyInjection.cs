using Application.SPG.Common.Interfaces;
using Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Cache;
using Persistence.SPG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceSPG(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SPGContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("SPGConnection"), sqlServerOptions => sqlServerOptions.CommandTimeout(90)));

            services.AddScoped<ISPGContext>(provider => provider.GetService<SPGContext>() ?? throw new ArgumentNullException($"{typeof(ISPGContext)} could not be resolved"));
            services.AddSingleton<IMasterCache, MasterCache>();
            return services;
        }
    }
}
