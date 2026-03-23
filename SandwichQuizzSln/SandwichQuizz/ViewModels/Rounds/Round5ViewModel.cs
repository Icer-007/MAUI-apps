using SandwichQuizz.Enums;
using SandwichQuizz.Events;
using SandwichQuizz.Interfaces.Utils;

namespace SandwichQuizz.ViewModels.Rounds;

public partial class Round5ViewModel(
    IViewModelInjection viewModelInjection,
    IEnumerable<QuestionViewModel>? questions)
    : RoundViewModelBase(
        viewModelInjection,
        questions,
        Round.Round5)
{
    protected override void ShowResponse()
    {
        this.StopTimer();
        this.Sound.PlayLastRoundResult(true);
    }

    protected override void TimerStopped(object? sender, TimerStoppedEventArgs e)
    {
        if (e.IsExpired)
            this.Sound.PlayLastRoundResult(false);
    }
}
