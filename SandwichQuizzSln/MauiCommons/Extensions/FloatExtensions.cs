namespace MauiCommons.Extensions;

public static class FloatExtensions
{
    extension(float value)
    {
        public float AtLeast(float minValue)
            => Math.Max(minValue, value);

        public float AtMost(float maxValue)
            => Math.Min(value, maxValue);

        public float Between(float minValue, float maxValue)
            => value.AtLeast(minValue).AtMost(maxValue);

        public bool IsBetween(float minValue, float maxValue)
            => minValue <= value && value <= maxValue;

        public bool IsStrictlyBetween(float minValue, float maxValue)
            => minValue < value && value < maxValue;
    }
}
