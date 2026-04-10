using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Metadata;
namespace Aurum.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));
        return services;
    }
}

