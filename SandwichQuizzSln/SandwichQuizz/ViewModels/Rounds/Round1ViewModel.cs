using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Utils;

namespace SandwichQuizz.ViewModels.Rounds;

public partial class Round1ViewModel(
    IViewModelInjection viewModelInjection,
    IEnumerable<QuestionViewModel>? questions)
    : RoundViewModelBase(
        viewModelInjection,
        questions,
        Round.Round1)
{
    public override bool CanManuallyStartTimer => this.CurrentQuestion?.IsDisplayed is true
                                                  && this.CurrentQuestion?.IsRevealed is false;

    protected override bool CanGoBackward => this.CurrentQuestion is not null
                                             && this.questions.Count != 0
                                             && !object.ReferenceEquals(this.questions.First(), this.CurrentQuestion);

    protected override bool CanGoForward => this.CurrentQuestion?.IsDisplayed is false
                                            || (this.CurrentQuestion?.IsRevealed is not false
                                                && this.questions.Count != 0
                                                && !object.ReferenceEquals(this.questions.Last(), this.CurrentQuestion));

    protected override void GoBackward()
    {
        this.CurrentQuestion = this.questions.ElementAtOrDefault(this.questions.IndexOf(this.CurrentQuestion!) - 1);
    }

    protected override void GoForward()
    {
        if (this.CurrentQuestion?.DisplayNextAnswer() is false)
        {
            // No more answers to display : go to next question only if right answer is revealed
            if (this.CurrentQuestion?.IsRevealed is true)
            {
                this.CurrentQuestion = this.questions.ElementAtOrDefault(this.questions.IndexOf(this.CurrentQuestion) + 1);
            }
        }

        this.UpdateCanExecuteCommands();
    }

    protected override void ShowResponse()
    {
        if (this.CurrentQuestion?.SelectedAnswers.Any() is true)
        {
            this.StopTimer();
            this.CurrentQuestion?.Reveal();
            this.UpdateCanExecuteCommands();
        }
    }
}
