using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoWebApi.Conventions
{
    public class ConventionalControllerSettingList : List<ConventionalControllerSetting>
    {
        public ConventionalControllerSetting GetSettingOrNull(Type controllerType)
        {
            return this.FirstOrDefault(controllerSetting => controllerSetting.ControllerTypes.Contains(controllerType));
        }
    }
}
