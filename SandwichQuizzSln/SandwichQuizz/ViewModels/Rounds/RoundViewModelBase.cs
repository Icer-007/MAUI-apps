using MauiCommons;
using SandwichQuizz.Enums;
using SandwichQuizz.Events;
using SandwichQuizz.Extensions;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.Utils;
using SandwichQuizz.Interfaces.ViewModels;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels.Rounds;

public abstract partial class RoundViewModelBase : ViewModelBase
{
    protected readonly List<QuestionViewModel> questions;

    private readonly ISettingsService settingsService;

    public RoundViewModelBase(
        IViewModelInjection viewModelInjection,
        IEnumerable<QuestionViewModel>? questions,
        Round round) : base(viewModelInjection.LoggerService)
    {
        this.settingsService = viewModelInjection.SettingsService;
        this.Timer = viewModelInjection.TimerViewModel;
        this.Timer.Stopped += this.TimerStopped;
        this.Sound = viewModelInjection.SoundViewModel;
        this.questions = questions is not null
                         ? [.. questions]
                         : [];
        this.Round = round;

        this.CommandBackward = new RelayCommand(this.Backward, () => this.CanGoBackward);
        this.CommandForward = new RelayCommand(this.Forward, () => this.CanGoForward);
        this.CommandShowResponse = new RelayCommand(this.ShowResponse);
        this.CommandManualTimer = new RelayCommand(this.ManualTimer);

        this.CurrentQuestion = this.questions.FirstOrDefault();
    }

    ~RoundViewModelBase()
    {
        this.Timer.Stopped -= this.TimerStopped;
    }

    public virtual bool CanManuallyStartTimer => !this.Round.IsConcurrent();

    public ICommandRaisable CommandBackward { get; }

    public ICommandRaisable CommandForward { get; }

    public ICommandRaisable CommandManualTimer { get; }

    public ICommand CommandShowResponse { get; }

    public QuestionViewModel? CurrentQuestion
    {
        get => this.GetValue<QuestionViewModel>();
        protected set
        {
            value?.Reset();
            this.Timer.Stop();
            this.SetValue(value);
            this.UpdateCanExecuteCommands();
        }
    }

    public Round Round { get; }

    public ISoundViewModel Sound { get; }

    public ITimerViewModel Timer { get; }

    protected virtual bool CanGoBackward => false;

    protected virtual bool CanGoForward => false;

    public void StartTimer()
    {
        this.Timer.Start(this.settingsService.RoundCountDownInSeconds(this.Round));
    }

    public void StopTimer()
    {
        this.Timer.Stop();
    }

    protected virtual void GoBackward()
    { }

    protected virtual void GoForward()
    { }

    protected virtual void ShowResponse()
    { }

    protected virtual void TimerStopped(object? sender, TimerStoppedEventArgs e)
    {
        if (e.IsExpired)
        {
            this.Sound.PlayTimeOver();
        }
    }

    protected void UpdateCanExecuteCommands()
    {
        this.CommandBackward.RaiseCanExecuteChanged();
        this.CommandForward.RaiseCanExecuteChanged();
        this.OnPropertyChanged(nameof(this.CanManuallyStartTimer));
    }

    private void Backward()
    {
        if (this.CanGoBackward)
        {
            this.GoBackward();
        }
    }

    private void Forward()
    {
        if (this.CanGoForward)
        {
            this.GoForward();
        }
    }

    private void ManualTimer()
    {
        if (this.Timer.IsRunning)
        {
            this.StopTimer();
        }
        else if (this.CanManuallyStartTimer)
        {
            this.StartTimer();
        }
    }
}
