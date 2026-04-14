using Microsoft.Extensions.DependencyInjection;
using Traceability.Domain.ProductionEvents.Services;

namespace Traceability.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatorHandlers(typeof(DependencyInjection).Assembly);

        services.AddScoped<ICreateProductionEventService, CreateProductionEventService>();

        return services;
    }
}