using System.ComponentModel;
using System.Reflection;

namespace LondonStockExchange.Utility
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value) 
        {
            FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return value.ToString();

            DescriptionAttribute? descriptionAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return descriptionAttribute?.Description ?? value.ToString();
        }
    }
}
