using CommunityToolkit.Mvvm.Input;
using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Services;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels;

public partial class AnswerViewModel : ViewModelBase
{
    private const string PREFIX_ANSWER = "-";

    private const string PREFIX_RIGHTANSWER = "->";

    private readonly string displayPrefix;

    private readonly bool isRight;

    private readonly string[] prefixes = [PREFIX_ANSWER, PREFIX_RIGHTANSWER];

    private readonly string rawAnswer;

    public AnswerViewModel(ILoggerService logger, string answer, string? displayPrefix = null) : base(logger)
    {
        this.displayPrefix = displayPrefix ?? string.Empty;
        this.isRight = answer.StartsWith(PREFIX_RIGHTANSWER);

        int prefixLength = this.prefixes.Max(s => answer.StartsWith(s) ? s.Length : 0);
        this.rawAnswer = answer.Substring(prefixLength);

        this.CommandSelectMe = new RelayCommand(this.SelectMe);

        this.ShowMe();
    }

    public string Answer => $"{this.displayPrefix}{this.rawAnswer}";

    public ICommand CommandSelectMe { get; }

    public bool IsDisplayed => this.Status != AnswerStatus.Hidden;

    public bool IsRevealed => this.isRight && this.Status == AnswerStatus.RightAnswer;

    public AnswerStatus Status
    {
        get => this.GetValue<AnswerStatus>();
        private set => this.SetValue(value);
    }

    public void HideMe()
    {
        this.Status = AnswerStatus.Hidden;
    }

    public void ShowMe()
    {
        this.Status = AnswerStatus.Neutral;
    }

    public void RevealMe()
    {
        if (this.isRight)
        {
            this.Status = AnswerStatus.RightAnswer;
        }
    }

    public void SelectMe()
    {
        if (this.Status != AnswerStatus.Hidden
            && this.Status != AnswerStatus.RightAnswer)
        {
            this.Status = this.Status != AnswerStatus.SelectedAnswer
                          ? AnswerStatus.SelectedAnswer
                          : AnswerStatus.Neutral;
        }
    }
}
