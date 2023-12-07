using Castle.Core.Interceptor;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public Castle.Core.Interceptor.IInterceptor[] SelectInterceptors(Type type, MethodInfo method, Castle.Core.Interceptor.IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (true).ToList();
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}
