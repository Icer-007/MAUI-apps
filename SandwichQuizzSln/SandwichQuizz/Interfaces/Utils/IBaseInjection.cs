using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.Interfaces.Utils;

public interface IBaseInjection
{
    ILoggerService LoggerService { get; }

    ISettingsService SettingsService { get; }
}
