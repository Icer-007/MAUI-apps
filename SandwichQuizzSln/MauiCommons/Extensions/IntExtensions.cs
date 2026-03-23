namespace MauiCommons.Extensions;

public static class IntExtensions
{
    public static int AtLeast(this int value, int minValue)
        => Math.Max(minValue, value);

    public static int AtMost(this int value, int maxValue)
        => Math.Min(value, maxValue);

    public static int Between(this int value, int minValue, int maxValue)
        => value.AtLeast(minValue).AtMost(maxValue);
}
