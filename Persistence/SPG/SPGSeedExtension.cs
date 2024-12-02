using Application.SPG.Common.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Persistence.SPG
{
    public static class SPGSeedExtension
    {
        public static IApplicationBuilder SetupDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            var scopedServices = scope.ServiceProvider;

            var context = scopedServices.GetRequiredService<SPGContext>();
            var options = scopedServices.GetRequiredService<IOptions<DatabaseOptions>>();

            if(options.Value.ApplyMigration)
            {
                MigrateDatabase(context);
            }

            return app;
        }

        private static void MigrateDatabase(SPGContext context) => context.Database.Migrate();
    }
}
