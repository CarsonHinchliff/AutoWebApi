using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.Options
{
    public class AutoApiAspNetCoreMvcOptions
    {
        public bool? MinifyGeneratedScript { get; set; }

        public AutoApiConventionalControllerOptions ConventionalControllers { get; }

        public AutoApiAspNetCoreMvcOptions()
        {
            ConventionalControllers = new AutoApiConventionalControllerOptions();
        }
    }
}
