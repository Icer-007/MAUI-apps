using SandwichQuizz.Enums;
using System.Globalization;

namespace SandwichQuizz.Views.Converters;

public class AnswerStatusToColorConverter : IValueConverter
{
    public static Color NeutralColor => Colors.Black;

    public static Color RightAnswerColor => Colors.YellowGreen;

    public static Color SelectedAnswerColor => Colors.CadetBlue;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var statusVal = value as AnswerStatus?;
        var color = statusVal switch
        {
            AnswerStatus.SelectedAnswer => SelectedAnswerColor,

            AnswerStatus.RightAnswer => RightAnswerColor,

            AnswerStatus.Hidden => Colors.Transparent,

            AnswerStatus.Neutral
            or _ => NeutralColor,
        };

        return color;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
