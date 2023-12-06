using Autofac;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
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

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
    }
    
}
