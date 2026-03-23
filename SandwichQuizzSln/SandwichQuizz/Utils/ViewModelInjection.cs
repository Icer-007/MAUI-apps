using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.Utils;
using SandwichQuizz.Interfaces.ViewModels;

namespace SandwichQuizz.Utils;

internal class ViewModelInjection(
    ILoggerService loggerService,
    ISettingsService settingsService,
    ITimerViewModel timerViewModel,
    ISoundViewModel soundViewModel
    )
    : BaseInjection(loggerService, settingsService), IViewModelInjection
{
    public ISoundViewModel SoundViewModel { get; } = soundViewModel;

    public ITimerViewModel TimerViewModel { get; } = timerViewModel;
}
