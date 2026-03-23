using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Utils;

namespace SandwichQuizz.ViewModels.Rounds;

public partial class Round4ViewModel(
    IViewModelInjection viewModelInjection,
    IEnumerable<QuestionViewModel>? questions)
    : RoundViewModelBase(
        viewModelInjection,
        questions,
        Round.Round4)
{
}
