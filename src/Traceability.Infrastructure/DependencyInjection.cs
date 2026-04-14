using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Traceability.Domain.Equipments.Repositories;
using Traceability.Domain.Locations.Repositories;
using Traceability.Domain.Materials.Repositories;
using Traceability.Domain.ProcessSegments.Repositories;
using Traceability.Domain.ProductionEvents.Repositories;
using Traceability.Domain.ProductionRequests.Repositories;
using Traceability.Domain.ProductionSchedules.Repositories;
using Traceability.Domain.SegmentRequirements.Repositories;
using Traceability.Domain.SegmentResponses.Repositories;
using Traceability.Infrastructure.Persistence.DbContexts;
using Traceability.Infrastructure.Persistence.Interceptors;
using Traceability.Infrastructure.Persistence.Repositories;
using Traceability.SharedKernel;

namespace Traceability.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Database");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "The connection string to the database is not set");
        }

        services.AddSingleton<SetUpdatedAtInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, opt) =>
        {
            opt.UseSqlServer(connectionString, x =>
            {
                x.EnableRetryOnFailure();
                x.MigrationsHistoryTable("__EFMigrationsHistory");
            });

            if (sp.GetRequiredService<IHostEnvironment>().IsDevelopment())
            {
                opt.EnableSensitiveDataLogging();
            }

            opt.AddInterceptors(sp.GetRequiredService<SetUpdatedAtInterceptor>());
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IProcessSegmentRepository, ProcessSegmentRepository>();
        services.AddScoped<IProductionEventRepository, ProductionEventRepository>();
        services.AddScoped<IProductionRequestRepository, ProductionRequestRepository>();
        services.AddScoped<IProductionScheduleRepository, ProductionScheduleRepository>();
        services.AddScoped<ISegmentRequirementRepository, SegmentRequirementRepository>();
        services.AddScoped<ISegmentResponseRepository, SegmentResponseRepository>();


        return services;
    }
}
