using SandwichQuizz.Interfaces.ViewModels;

namespace SandwichQuizz.Interfaces.Utils;

public interface IViewModelInjection : IBaseInjection
{
    ISoundViewModel SoundViewModel { get; }

    ITimerViewModel TimerViewModel { get; }
}
