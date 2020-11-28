using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoWebApi.Options;

namespace AutoWebApi.Conventions
{
    public class AutoApiConventionalControllerFeatureProvider: ControllerFeatureProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoApiConventionalControllerFeatureProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override bool IsController(TypeInfo typeInfo)
        {
            var configuration = _serviceProvider
                .GetRequiredService<IOptions<AutoApiAspNetCoreMvcOptions>>().Value
                .ConventionalControllers
                .ConventionalControllerSettings
                .GetSettingOrNull(typeInfo.AsType());

            return configuration != null;
        }
    }
}
