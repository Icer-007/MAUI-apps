using MauiCommons;
using MauiCommons.Enums;
using SandwichQuizz.Enums;
using SandwichQuizz.Events;
using SandwichQuizz.Extensions;
using SandwichQuizz.Interfaces.Factories;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.ViewModels;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public readonly ITimerViewModel timerVM;

    public MainViewModel(ILoggerService logger, IViewModelFactory viewModelFactory, ITimerViewModel timerViewModel) : base(logger)
    {
        this.timerVM = timerViewModel;

        this.SetProperties = viewModelFactory.GetSetPropertiesViewModel(1);
        this.Set = viewModelFactory.GetSetViewModel();
        this.timerVM.Stopped += this.TimerStopped;

        this.ScoreA = viewModelFactory.GetScoreViewModel(this.SetProperties, Team.A);
        this.ScoreB = viewModelFactory.GetScoreViewModel(this.SetProperties, Team.B);

        this.CommandKey = new RelayCommand(async p => await this.Key(p));
        this.CommandSelectTeam = new RelayCommand(p => this.SelectTeam(p as ScoreViewModel));

        this.Shortcuts =
            [
                WindowsSystemVirtualKey.Left,
                WindowsSystemVirtualKey.Right,
                WindowsSystemVirtualKey.Add,
                WindowsSystemVirtualKey.Subtract,
                WindowsSystemVirtualKey.Up,
                WindowsSystemVirtualKey.Down,
            ];
    }

    ~MainViewModel()
    {
        this.timerVM.Stopped -= this.TimerStopped;
    }

    public ICommand CommandKey { get; }

    public ICommand CommandSelectTeam { get; }

    public ScoreViewModel ScoreA { get; }

    public ScoreViewModel ScoreB { get; }

    public ScoreViewModel? SelectedScore
    {
        get => this.GetValue<ScoreViewModel>();
        set
        {
            this.SetValue(value);
            this.OnPropertyChanged(nameof(this.SelectedTeam));
        }
    }

    public Team SelectedTeam => this.SelectedScore?.Team ?? Team.None;

    public SetViewModel Set { get; }

    public SetPropertiesViewModel SetProperties { get; }

    public IEnumerable<WindowsSystemVirtualKey> Shortcuts { get; }

    private async Task Key(object param)
    {
        if (param is WindowsSystemVirtualKey key)
        {
            switch (key)
            {
                case WindowsSystemVirtualKey.Left:
                    this.SelectTeam(this.ScoreA); break;

                case WindowsSystemVirtualKey.Right:
                    this.SelectTeam(this.ScoreB); break;

                case WindowsSystemVirtualKey.Add:
                    this.SetProperties.UpdatePoints(true); break;

                case WindowsSystemVirtualKey.Subtract:
                    this.SetProperties.UpdatePoints(false); break;

                case WindowsSystemVirtualKey.Up:
                    this.SelectedScore?.CommandAddScore?.Execute(true); break;

                case WindowsSystemVirtualKey.Down:
                    this.SelectedScore?.CommandAddScore?.Execute(false); break;

                default:

                    //await this.logger.PopMessageAsync($"{param}", "oups");
                    break;
            }
        }
    }

    private void SelectTeam(ScoreViewModel? team)
    {
        if (object.ReferenceEquals(this.SelectedScore, team))
        {
            team = null;
        }

        if (this.Set.CurrentRound?.Round.IsConcurrent() ?? false)
        {
            this.timerVM.Stop();
        }

        this.SelectedScore = team;
        this.ScoreA.IsSelected = object.ReferenceEquals(this.ScoreA, this.SelectedScore);
        this.ScoreB.IsSelected = object.ReferenceEquals(this.ScoreB, this.SelectedScore);

        if (this.Set.CurrentRound?.Round.IsConcurrent() ?? false)
        {
            if (this.SelectedScore is not null)
            {
                this.Set.CurrentRound?.StartTimer();
            }
        }
    }

    private void TimerStopped(object? sender, TimerStoppedEventArgs e)
    {
        if (this.Set.CurrentRound?.Round.IsConcurrent() ?? false)
        {
            this.SelectTeam(null);
        }
    }
}
