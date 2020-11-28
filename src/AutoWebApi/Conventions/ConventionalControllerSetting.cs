using AutoWebApi.Extensions;
using AutoWebApi.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoWebApi.Conventions
{
    public class ConventionalControllerSetting
    {
        public Assembly Assembly { get; }

        
        public HashSet<Type> ControllerTypes { get; } //TODO: Internal?

        
        public string RootPath
        {
            get => _rootPath;
            set
            {
                _rootPath = value;
            }
        }
        private string _rootPath;

        
        public string RemoteServiceName
        {
            get => _remoteServiceName;
            set
            {
                _remoteServiceName = value;
            }
        }
        private string _remoteServiceName;

        public Func<Type, bool> TypePredicate { get; set; }


        public Action<ControllerModel> ControllerModelConfigurer { get; set; }


        public Func<UrlControllerNameNormalizerContext, string> UrlControllerNameNormalizer { get; set; }


        public Func<UrlActionNameNormalizerContext, string> UrlActionNameNormalizer { get; set; }

        public ConventionalControllerSetting(
             Assembly assembly,
             string rootPath,
             string remoteServiceName)
        {
            Assembly = assembly;
            RootPath = rootPath;
            RemoteServiceName = remoteServiceName;

            ControllerTypes = new HashSet<Type>();
        }

        public void Initialize()
        {
            var types = Assembly.GetTypes()
                .Where(IsRemoteService)
                .WhereIf(TypePredicate != null, TypePredicate);

            foreach (var type in types)
            {
                ControllerTypes.Add(type);
            }
        }

        private static bool IsRemoteService(Type type)
        {
            if (!type.IsPublic || type.IsAbstract || type.IsGenericType)
            {
                return false;
            }

            var remoteServiceAttr = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(type);
            if (remoteServiceAttr != null && !remoteServiceAttr.IsEnabledFor(type))
            {
                return false;
            }

            if (typeof(IRemoteService).IsAssignableFrom(type))
            {
                return true;
            }

            return false;
        }
    }
}
