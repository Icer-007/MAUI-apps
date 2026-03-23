using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.Utils;

namespace SandwichQuizz.Utils;

internal class BaseInjection(ILoggerService loggerService, ISettingsService settingsService) : IBaseInjection
{
    public ILoggerService LoggerService { get; } = loggerService;

    public ISettingsService SettingsService { get; } = settingsService;
}
