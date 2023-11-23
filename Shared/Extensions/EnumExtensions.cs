using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ExtensaoCurricular.Shared.Extensions;

public static class EnumExtensions
{
    public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Description;

        return enumValue.ToString();
    }

    public static string ToDisplay<TEnum>(this TEnum enumValue) where TEnum : struct
    {
        var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
        var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

        if (attributes != null && attributes.Length > 0)
            return attributes[0].Name;

        return enumValue.ToString();
    }

    public static IEnumerable<Enum> GetFlaggedValues(this Enum enumValue)
    {
        return Enum.GetValues(enumValue.GetType()).Cast<Enum>().Where(enumValue.HasFlag);
    }
}