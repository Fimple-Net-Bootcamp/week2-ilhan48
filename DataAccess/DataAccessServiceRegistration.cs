using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<WeatherDbContext>();

    }
}
