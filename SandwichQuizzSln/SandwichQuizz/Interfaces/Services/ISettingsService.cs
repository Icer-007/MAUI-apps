using SandwichQuizz.Enums;

namespace SandwichQuizz.Interfaces.Services;

public interface ISettingsService
{
    int CountDownInSeconds { get; set; }

    int RoundCountDownInSeconds(Round round);
}
