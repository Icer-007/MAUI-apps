using SandwichQuizz.Enums;
using System.Globalization;

namespace SandwichQuizz.Views.Converters;

public class TeamToColorConverter : IValueConverter
{
    public static Color ColorNone => Colors.BlueViolet;

    public static Color ColorTeamA => Colors.OrangeRed;

    public static Color ColorTeamB => Colors.Gold;

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var teamVal = value as Team?;
        var color = teamVal switch
        {
            Team.A => ColorTeamA,

            Team.B => ColorTeamB,

            Team.None
            or _ => ColorNone,
        };

        return color;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
