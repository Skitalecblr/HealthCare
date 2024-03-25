using System.ComponentModel;
using System.Reflection;

namespace HealthCare.Api.Infrastructure.Helpers
{
    public static class EnumsHelper
    {
        public static string[] GetEnumDescriptions<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(value =>
                {
                    var fieldInfo = value.GetType().GetField(value.ToString());
                    var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
                    return attribute?.Description ?? value.ToString();
                })
                .ToArray();
        }
    }
}
