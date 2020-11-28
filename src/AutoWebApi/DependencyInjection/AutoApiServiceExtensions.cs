using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoWebApi.Extensions;
using AutoWebApi.Conventions;
using AutoWebApi.Options;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace AutoWebApi.DependencyInjection
{
    public static class AutoApiServiceExtensions
    {
        public static IServiceCollection AddAutoWebApi(this IServiceCollection services, Assembly assembly, Action<ConventionalControllerSetting> optionsAction = null)
        {
            var partManager = services.BuildServiceProvider().GetRequiredService<ApplicationPartManager>();

            services.AddTransient<IAutoApiServiceConvention, AutoApiServiceConvention>();

            services.Configure<MvcOptions>(o =>
            {
                o.Conventions.Add(new AutoApiServiceConventionWrapper(services));
            });

            services.Configure<AutoApiAspNetCoreMvcOptions>(o =>
            {
                o.ConventionalControllers.Create(assembly, optionsAction);
            });

            partManager.FeatureProviders.Add(new AutoApiConventionalControllerFeatureProvider(services.BuildServiceProvider()));


            return services;
        }
    }
}
