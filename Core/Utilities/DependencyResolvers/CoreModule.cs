﻿using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.Utilities.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();

        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        serviceCollection.AddSingleton<Stopwatch>();
    }
}
