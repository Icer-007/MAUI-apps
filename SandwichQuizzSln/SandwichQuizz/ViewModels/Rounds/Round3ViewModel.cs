using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Utils;
using System.ComponentModel;

namespace SandwichQuizz.ViewModels.Rounds;

public partial class Round3ViewModel : RoundViewModelBase
{
    private readonly ILookup<string, QuestionViewModel> themeQuestions;

    private readonly QuestionViewModel? themeTitles;

    private List<QuestionViewModel>? selectedTheme;

    public Round3ViewModel(
        IViewModelInjection viewModelInjection,
        IEnumerable<QuestionViewModel>? questions)
        : base(
            viewModelInjection,
            questions,
            Round.Round3)
    {
        this.themeTitles = this.questions.FirstOrDefault();
        this.themeQuestions = this.questions.Skip(1).ToLookup(q => q.Question);

        if (this.themeTitles is not null)
        {
            foreach (var item in this.themeTitles.Answers)
            {
                item.HideMe();
                item.PropertyChanged += this.ThemeTitlePropertyChanged;
            }
        }
    }

    ~Round3ViewModel()
    {
        if (this.themeTitles is not null)
        {
            foreach (var item in this.themeTitles.Answers)
                item.PropertyChanged -= this.ThemeTitlePropertyChanged;
        }
    }

    public override bool CanManuallyStartTimer => this.CurrentQuestion is not null
                                                  && !object.ReferenceEquals(this.CurrentQuestion, this.themeTitles);

    protected override bool CanGoBackward => this.CurrentQuestion is null
                                             || !object.ReferenceEquals(this.CurrentQuestion, this.themeTitles);

    protected override bool CanGoForward => this.CurrentQuestion is null
                                            || !object.ReferenceEquals(this.CurrentQuestion, this.themeTitles)
                                            || !this.CurrentQuestion.IsDisplayed
                                            || this.CurrentQuestion.SelectedAnswers.Count() == 1;

    protected override void GoBackward()
    {
        if (this.CurrentQuestion is null)
        {
            this.CurrentQuestion = this.selectedTheme?.LastOrDefault()
                                   ?? this.themeTitles;
        }
        else if (object.ReferenceEquals(this.CurrentQuestion, this.selectedTheme?.FirstOrDefault()))
        {
            this.CurrentQuestion = this.themeTitles;
        }
        else
        {
            this.CurrentQuestion = this.selectedTheme?.ElementAtOrDefault(this.selectedTheme.IndexOf(this.CurrentQuestion) - 1);
        }
    }

    protected override void GoForward()
    {
        if (this.CurrentQuestion is null)
        {
            this.CurrentQuestion = this.themeTitles;
        }
        else if (object.ReferenceEquals(this.CurrentQuestion, this.themeTitles))
        {
            if (this.CurrentQuestion.DisplayNextAnswer() is false)
            {
                // No more answers to display : start selected theme if any
                if (this.CurrentQuestion?.SelectedAnswers.FirstOrDefault()?.Answer is string theme)
                {
                    this.selectedTheme = [.. this.themeQuestions[theme]];
                    this.CurrentQuestion = this.selectedTheme.FirstOrDefault();
                }
            }
        }
        else
        {
            this.CurrentQuestion = this.selectedTheme?.ElementAtOrDefault(this.selectedTheme.IndexOf(this.CurrentQuestion!) + 1);
        }
    }

    private void ThemeTitlePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AnswerViewModel.Status))
        {
            this.UpdateCanExecuteCommands();
        }
    }
}
