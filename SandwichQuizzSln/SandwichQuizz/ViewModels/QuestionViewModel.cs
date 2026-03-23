using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.ViewModels;

public partial class QuestionViewModel : ViewModelBase
{
    public QuestionViewModel(ILoggerService logger, string question, IEnumerable<string> answers, Round round) : base(logger)
    {
        this.Question = question;
        this.Round = round;
        var c = 'a';
        this.Answers =
            this.Round switch
            {
                Round.Round1 => [.. answers.Select(a => new AnswerViewModel(this.logger, a, $" {c++}) "))],

                Round.Round2
                or Round.Round3
                or Round.Round4 => [.. answers.Select(a => new AnswerViewModel(this.logger, a, null))],

                Round.Round5
                or _ => [],
            };

        this.Reset();
    }

    public AnswerViewModel[] Answers { get; }

    public bool IsDisplayed => this.Answers.All(a => a.IsDisplayed);

    public bool IsRevealed => this.Answers.Any(a => a.IsRevealed);

    public string Question { get; }

    public Round Round { get; }

    public IEnumerable<AnswerViewModel> SelectedAnswers => this.Answers.Where(a => a.Status == AnswerStatus.SelectedAnswer);

    public bool DisplayNextAnswer()
    {
        if (this.Answers.FirstOrDefault(a => !a.IsDisplayed) is AnswerViewModel nextAnswer)
        {
            nextAnswer.ShowMe();
            return true;
        }

        return false;
    }

    public void Reset()
    {
        if (this.Round == Round.Round1)
        {
            foreach (var answer in this.Answers)
                answer.HideMe();
        }
        else
        {
            foreach (var answer in this.Answers)
                answer.ShowMe();
        }
    }

    public void Reveal()
    {
        foreach (var answer in this.Answers)
        {
            answer.RevealMe();
        }
    }
}
