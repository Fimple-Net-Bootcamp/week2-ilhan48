using Core.Utilities.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddDependencyResolvers(new ICoreModule[] {
                new CoreModule()
            });
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}
