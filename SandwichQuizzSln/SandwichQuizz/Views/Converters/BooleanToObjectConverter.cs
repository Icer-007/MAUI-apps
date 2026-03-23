using System.Globalization;

namespace SandwichQuizz.Views.Converters;

public class BooleanToObjectConverter : IValueConverter
{
    public object? FalseValue { get; set; }

    public object? TrueValue { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => (value as bool?).GetValueOrDefault(false)
           ? this.TrueValue
           : this.FalseValue;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value == this.TrueValue;
}
