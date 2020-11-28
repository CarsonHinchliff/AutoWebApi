using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.GlobalFeatures
{
    [AttributeUsage(AttributeTargets.Class)]
    public class RequiresGlobalFeatureAttribute : Attribute
    {
        public Type Type { get; }

        public string Name { get; }

        public RequiresGlobalFeatureAttribute(Type type)
        {
            Type = type;
        }

        public RequiresGlobalFeatureAttribute(string name)
        {
            Name = name;
        }

        public virtual string GetFeatureName()
        {
            return Name ?? GlobalFeatureNameAttribute.GetName(Type);
        }
    }
}
