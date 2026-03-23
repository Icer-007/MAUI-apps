using SandwichQuizz.Enums;
using SandwichQuizz.ViewModels;
using SandwichQuizz.ViewModels.Rounds;

namespace SandwichQuizz.Interfaces.Factories;

public interface IViewModelFactory
{
    QuestionViewModel GetQuestionViewModel(string question, IEnumerable<string> answers, Round round);

    RoundViewModelBase GetRoundEmptyViewModel();

    RoundViewModelBase GetRoundViewModel(QuestionViewModel[] questions);

    ScoreViewModel GetScoreViewModel(SetPropertiesViewModel setProperties, Team team);

    SetPropertiesViewModel GetSetPropertiesViewModel(int initialPoints);

    SetViewModel GetSetViewModel();
}
