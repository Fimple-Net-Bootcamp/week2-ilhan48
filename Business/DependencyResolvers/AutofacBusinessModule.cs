using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
        builder.RegisterType<UserDal>().As<IUserDal>().SingleInstance();

        builder.RegisterType<SatelliteDal>().As<ISatelliteDal>().SingleInstance();
        builder.RegisterType<SatelliteManager>().As<ISatelliteService>().SingleInstance();

        builder.RegisterType<AuthManager>().As<IAuthService>();
        builder.RegisterType<JwtHelper>().As<ITokenHelper>();

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

    }
    
}
