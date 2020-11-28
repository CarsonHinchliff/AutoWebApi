using AutoWebApi.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace AutoWebApi.GlobalFeatures
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GlobalFeatureNameAttribute : Attribute
    {
        public string Name { get; }

        public GlobalFeatureNameAttribute(string name)
        {
            Name = name;
        }

        public static string GetName<TFeature>()
            where TFeature : GlobalFeature
        {
            return GetName(typeof(TFeature));
        }

        public static string GetName(Type type)
        {
            var attribute = type
                .GetCustomAttributes<GlobalFeatureNameAttribute>()
                .FirstOrDefault();

            if (attribute == null)
            {
                throw new Exception($"{type.AssemblyQualifiedName} should define the {typeof(GlobalFeatureNameAttribute).FullName} atttribute!");
            }

            return attribute
                .As<GlobalFeatureNameAttribute>()
                .Name;
        }
    }
}
