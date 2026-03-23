using MauiCommons.Attributes;
using System.Reflection;

namespace MauiCommons.Extensions;

public static class MemberInfoExtensions
{
    public static string? GetAttributeStringValue<T>(this MemberInfo src) where T : ValueAttributeBase<string>
        => src?.GetCustomAttributes(true)
               .OfType<T>()
               .FirstOrDefault()?
               .Value;

    public static TVALUE? GetAttributeValue<TATTRIBUTE, TVALUE>(this MemberInfo src) where TATTRIBUTE : ValueAttributeBase<TVALUE>
    {
        var attr = src?.GetCustomAttributes(true)
                       .OfType<TATTRIBUTE>()
                       .FirstOrDefault();

        return attr != null
               ? attr.Value
               : default;
    }

    public static bool HasCustomAttribute<T>(this MemberInfo src) where T : Attribute
        => src?.GetCustomAttributes(true)
               .OfType<T>()
               .Any()
           ?? false;
}
