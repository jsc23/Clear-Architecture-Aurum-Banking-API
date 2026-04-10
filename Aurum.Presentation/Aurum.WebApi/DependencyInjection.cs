
using Aurum.Api.Common.Mapping;
using Aurum.Api.Service;
using MediatR;

namespace Aurum.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<JwtService>();
        return services;
    }
}

