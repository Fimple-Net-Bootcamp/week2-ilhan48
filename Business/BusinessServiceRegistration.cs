using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static void AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<ISatelliteService, SatelliteManager>();
        services.AddScoped<IUserDal, UserDal>();
        services.AddScoped<ISatelliteDal, SatelliteDal>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IPlanetDal, PlanetDal>();
        services.AddScoped<IPlanetService, PlanetManager>();
              
    }
}
