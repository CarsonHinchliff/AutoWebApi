using AutoWebApi.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoWebApi.Modeling
{
    public static class ApiTypeNameHelper
    {
        public static string GetTypeName(Type type)
        {
            if (TypeHelper.IsDictionary(type, out var keyType, out var valueType))
            {
                return $"{{{GetTypeName(keyType)}:{GetTypeName(valueType)}}}";
            }

            if (TypeHelper.IsEnumerable(type, out var itemType, includePrimitives: false))
            {
                return $"[{GetTypeName(itemType)}]";
            }

            return TypeHelper.GetFullNameHandlingNullableAndGenerics(type);
        }

        public static string GetSimpleTypeName(Type type)
        {
            if (TypeHelper.IsDictionary(type, out var keyType, out var valueType))
            {
                return $"{{{GetSimpleTypeName(keyType)}:{GetSimpleTypeName(valueType)}}}";
            }

            if (TypeHelper.IsEnumerable(type, out var itemType, includePrimitives: false))
            {
                return $"[{GetSimpleTypeName(itemType)}]";
            }

            return TypeHelper.GetSimplifiedName(type);
        }
    }
}
