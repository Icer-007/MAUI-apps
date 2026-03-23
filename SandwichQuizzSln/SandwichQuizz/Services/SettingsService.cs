using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.Services;

public class SettingsService : ISettingsService
{
    private const string COUNTDOWNINSECONDS = "count_down_in_seconds";

    private const int COUNTDOWNINSECONDS_DEFAULT = 5;

    public int CountDownInSeconds
    {
        get => Preferences.Get(COUNTDOWNINSECONDS, COUNTDOWNINSECONDS_DEFAULT);
        set => Preferences.Set(COUNTDOWNINSECONDS, value);
    }

    public int RoundCountDownInSeconds(Round round)
        => round switch
        {
            Round.Round1
            or Round.Round3 => 20,

            Round.Round2
            or Round.Round4 => 5,

            Round.Round5 => 60,

            _ => 5
        };
}
