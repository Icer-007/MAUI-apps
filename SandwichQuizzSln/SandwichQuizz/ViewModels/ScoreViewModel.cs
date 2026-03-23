using MauiCommons;
using MauiCommons.Extensions;
using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Services;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels;

public partial class ScoreViewModel : ViewModelBase
{
    private const int MAX_SCORE = 25;

    private const int MIN_SCORE = 0;

    private readonly SetPropertiesViewModel setProperties;

    public ScoreViewModel(ILoggerService logger, SetPropertiesViewModel setProperties, Team team) : base(logger)
    {
        this.setProperties = setProperties;
        this.Team = team;

        this.CommandAddScore = new RelayCommand(this.AddScore);
    }

    public ICommand CommandAddScore { get; }

    public bool IsSelected
    {
        get => this.GetValue<bool>();
        set => this.SetValue(value);
    }

    public int Score
    {
        get => this.GetValue<int>();
        set => this.SetValue(value);
    }

    public Team Team { get; }

    private void AddScore(object param)
    {
        int way = bool.TryParse(param?.ToString(), out bool boolParam) && boolParam ? 1 : -1;
        this.Score = (this.Score + way * this.setProperties.Points).Between(MIN_SCORE, MAX_SCORE);
    }
}
