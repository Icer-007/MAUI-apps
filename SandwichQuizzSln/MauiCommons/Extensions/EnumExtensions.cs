using System.Reflection;

namespace MauiCommons.Extensions;

public static class EnumExtensions
{
    public static FieldInfo GetField<T>(this T value) where T : Enum
    {
        var enumType = value.GetType();

        return enumType.GetField(Enum.GetName(enumType, value)!)!;
    }
}
