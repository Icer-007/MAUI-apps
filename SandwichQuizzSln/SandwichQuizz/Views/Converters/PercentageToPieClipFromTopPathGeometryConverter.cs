using SandwichQuizz.Extensions;
using System.Globalization;

namespace SandwichQuizz.Views.Converters;

public class PercentageToPieClipFromTopPathGeometryConverter : IValueConverter
{
    public SweepDirection SweepDirection { get; set; }

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => (parameter as VisualElement)?.GetPieClipFromTopPathGeometry(value is float percentage ? 1 - percentage / 100f : 1, this.SweepDirection);

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
