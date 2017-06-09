using System;
using System.Linq;
using System.Reflection;
using Goodreads.Http;

namespace Goodreads.Helpers
{
    internal static class EnumHelpers
    {
        public static string QueryParameterKey<T>() where T : struct
        {
            QueryParameterKeyAttribute attribute = null;
            try
            {
                attribute = typeof(T).GetCustomAttribute<QueryParameterKeyAttribute>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attribute != null
                ? attribute.QueryParameterKey
                : string.Empty;
        }

        public static string QueryParameterValue<T>(T source) where T : struct
        {
            var fieldInfo = source.GetType().GetField(source.ToString());
            var attribute = (QueryParameterValueAttribute)fieldInfo.GetCustomAttribute(typeof(QueryParameterValueAttribute), false);

            return attribute != null
                ? attribute.QueryParameterValue
                : null;
        }

        public static T GetCustomAttribute<T>(this Type type) where T : Attribute
        {
            var attribute = type.GetTypeInfo().GetCustomAttribute<T>();
            if (attribute == null)
            {
                return attribute;
            }
          //  var attribute = typeof(T).GetCustomAttribute<T>();
            return attribute;
        }
    }
}
