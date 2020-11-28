using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.Conventions
{
    public class AutoApiServiceConventionWrapper : IApplicationModelConvention
    {
        private readonly IAutoApiServiceConvention _convention;

        public AutoApiServiceConventionWrapper(IServiceCollection services)
        {
            _convention = services.BuildServiceProvider().GetService<IAutoApiServiceConvention>();
        }

        public void Apply(ApplicationModel application)
        {
            _convention?.Apply(application);
        }
    }
}
