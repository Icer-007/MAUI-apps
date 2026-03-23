using CommunityToolkit.Maui.Views;
using System.Globalization;

namespace SandwichQuizz.Views.Converters;

public class ResIdToMediaSourceConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var strVal = value as string;
        if (!string.IsNullOrWhiteSpace(strVal))
        {
            try
            {
                return MediaSource.FromResource(strVal);
            }
            catch { }
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
