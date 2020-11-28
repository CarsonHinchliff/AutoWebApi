using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.Modeling
{
    [Serializable]
    public class ControllerInterfaceApiDescriptionModel
    {
        public string Type { get; set; }

        private ControllerInterfaceApiDescriptionModel()
        {

        }

        public static ControllerInterfaceApiDescriptionModel Create(Type type)
        {
            return new ControllerInterfaceApiDescriptionModel
            {
                Type = type.FullName
            };
        }
    }
}
