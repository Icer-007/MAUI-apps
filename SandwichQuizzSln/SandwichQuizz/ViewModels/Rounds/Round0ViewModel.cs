using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Utils;

namespace SandwichQuizz.ViewModels.Rounds;

public partial class Round0ViewModel(IViewModelInjection viewModelInjection)
    : RoundViewModelBase(
        viewModelInjection,
        [],
        Round.Round0)
{
    public override bool CanManuallyStartTimer => false;

    protected override bool CanGoBackward => false;

    protected override bool CanGoForward => false;
}
