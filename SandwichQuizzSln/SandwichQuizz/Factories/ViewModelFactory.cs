using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Factories;
using SandwichQuizz.Interfaces.Utils;
using SandwichQuizz.ViewModels;
using SandwichQuizz.ViewModels.Rounds;

namespace SandwichQuizz.Factories;

public class ViewModelFactory : IViewModelFactory
{
    private readonly IViewModelInjection viewModelInjection;

    public ViewModelFactory(IViewModelInjection viewModelInjection)
    {
        this.viewModelInjection = viewModelInjection;
    }

    public QuestionViewModel GetQuestionViewModel(string question, IEnumerable<string> answers, Round round)
        => new(this.viewModelInjection.LoggerService, question, answers, round);

    public RoundViewModelBase GetRoundEmptyViewModel()
        => new Round0ViewModel(this.viewModelInjection);

    public RoundViewModelBase GetRoundViewModel(QuestionViewModel[] questions)
    {
        Round round = questions?.FirstOrDefault()?.Round
                      ?? Round.Round5;

        return round switch
        {
            Round.Round1 => new Round1ViewModel(this.viewModelInjection, questions),
            Round.Round2 => new Round2ViewModel(this.viewModelInjection, questions),
            Round.Round3 => new Round3ViewModel(this.viewModelInjection, questions),
            Round.Round4 => new Round4ViewModel(this.viewModelInjection, questions),

            Round.Round5
            or _ => new Round5ViewModel(this.viewModelInjection, questions),
        };
    }

    public ScoreViewModel GetScoreViewModel(SetPropertiesViewModel setProperties, Team team)
            => new(this.viewModelInjection.LoggerService, setProperties, team);

    public SetPropertiesViewModel GetSetPropertiesViewModel(int initialPoints)
        => new(this.viewModelInjection.LoggerService, initialPoints);

    public SetViewModel GetSetViewModel()
        => new(this.viewModelInjection.LoggerService, this, this.viewModelInjection.SoundViewModel);
}
