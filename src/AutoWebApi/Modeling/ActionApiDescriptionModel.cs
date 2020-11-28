using AutoWebApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace AutoWebApi.Modeling
{
    [Serializable]
    public class ActionApiDescriptionModel
    {
        public string UniqueName { get; set; }

        public string Name { get; set; }

        public string HttpMethod { get; set; }

        public string Url { get; set; }

        public IList<string> SupportedVersions { get; set; }

        public IList<MethodParameterApiDescriptionModel> ParametersOnMethod { get; set; }

        public IList<ParameterApiDescriptionModel> Parameters { get; set; }

        public ReturnValueApiDescriptionModel ReturnValue { get; set; }

        private ActionApiDescriptionModel()
        {

        }

        public static ActionApiDescriptionModel Create( string uniqueName, MethodInfo method,  string url,  string httpMethod,  IList<string> supportedVersions)
        {
            return new ActionApiDescriptionModel
            {
                UniqueName = uniqueName,
                Name = method.Name,
                Url = url,
                HttpMethod = httpMethod,
                ReturnValue = ReturnValueApiDescriptionModel.Create(method.ReturnType),
                Parameters = new List<ParameterApiDescriptionModel>(),
                ParametersOnMethod = method
                    .GetParameters()
                    .Select(MethodParameterApiDescriptionModel.Create)
                    .ToList(),
                SupportedVersions = supportedVersions
            };
        }

        public ParameterApiDescriptionModel AddParameter(ParameterApiDescriptionModel parameter)
        {
            Parameters.Add(parameter);
            return parameter;
        }

        public HttpMethod GetHttpMethod()
        {
            return HttpMethodHelper.ConvertToHttpMethod(HttpMethod);
        }

        public override string ToString()
        {
            return $"[ActionApiDescriptionModel {Name}]";
        }
    }
}
