using AutoWebApi.Conventions;
using AutoWebApi.Modeling;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AutoWebApi.Options
{
    public class AutoApiConventionalControllerOptions
    {
        public ConventionalControllerSettingList ConventionalControllerSettings { get; }

        public List<Type> FormBodyBindingIgnoredTypes { get; }

        public AutoApiConventionalControllerOptions()
        {
            ConventionalControllerSettings = new ConventionalControllerSettingList();

            FormBodyBindingIgnoredTypes = new List<Type>
            {
                typeof(IFormFile)
            };
        }

        public AutoApiConventionalControllerOptions Create(
            Assembly assembly,
            Action<ConventionalControllerSetting> optionsAction = null)
        {
            var setting = new ConventionalControllerSetting(
                assembly,
                ModuleApiDescriptionModel.DefaultRootPath,
                ModuleApiDescriptionModel.DefaultRemoteServiceName
            );

            optionsAction?.Invoke(setting);
            setting.Initialize();
            ConventionalControllerSettings.Add(setting);
            return this;
        }
    }
}
