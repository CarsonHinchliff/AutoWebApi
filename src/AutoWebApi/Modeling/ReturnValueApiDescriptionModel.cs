using AutoWebApi.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.Modeling
{
    [Serializable]
    public class ReturnValueApiDescriptionModel
    {
        public string Type { get; set; }

        public string TypeSimple { get; set; }

        private ReturnValueApiDescriptionModel()
        {

        }

        public static ReturnValueApiDescriptionModel Create(Type type)
        {
            var unwrappedType = AsyncHelper.UnwrapTask(type);

            return new ReturnValueApiDescriptionModel
            {
                Type = TypeHelper.GetFullNameHandlingNullableAndGenerics(unwrappedType),
                TypeSimple = ApiTypeNameHelper.GetSimpleTypeName(unwrappedType)
            };
        }
    }
}
