using Microsoft.EntityFrameworkCore;
using Traceability.Infrastructure.Persistence.DbContexts;

namespace Traceability.WebAPI.Extensions;

public static partial class ApplicationBuilderExtensions
{
    public static IApplicationBuilder MigrateDatabases(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>()
            .Database.Migrate();

        return app;
    }
}
