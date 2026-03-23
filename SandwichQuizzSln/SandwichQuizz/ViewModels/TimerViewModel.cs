using SandwichQuizz.Events;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.ViewModels;
using System.Diagnostics;

namespace SandwichQuizz.ViewModels;

public partial class TimerViewModel : ViewModelBase, ITimerViewModel
{
    private readonly IDispatcherTimer? dispatcherTimer;

    private readonly Stopwatch stopwatch;

    private int delayInSeconds;

    public TimerViewModel(ILoggerService logger) : base(logger)
    {
        this.stopwatch = new Stopwatch();
        this.dispatcherTimer = Application.Current?.Dispatcher.CreateTimer();
        if (this.dispatcherTimer is not null)
        {
            this.dispatcherTimer.Interval = TimeSpan.FromMilliseconds(16);
            this.dispatcherTimer.Tick += this.TimerTick;
        }
    }

    ~TimerViewModel()
    {
        this.dispatcherTimer?.Tick -= this.TimerTick;
    }

    public event EventHandler<TimerStoppedEventArgs>? Stopped;

    public bool IsRunning => this.stopwatch.IsRunning;

    public float PercentageProgression
    {
        get => this.GetValue<float>();
        private set => this.SetValue(value);
    }

    public void Start(int delayInSeconds)
    {
        this.TimerStop(false);

        this.TimerStart(delayInSeconds);
    }

    public void Stop()
    {
        this.TimerStop(false);
    }

    protected virtual void OnTimerStopped(bool isExpired)
    {
        this.Stopped?.Invoke(this, new TimerStoppedEventArgs(isExpired));
    }

    private void TimerStart(int delayInSeconds)
    {
        this.delayInSeconds = delayInSeconds;
        this.PercentageProgression = 0;

        this.stopwatch.Restart();
        this.OnPropertyChanged(nameof(this.IsRunning));

        this.dispatcherTimer?.Start();
    }

    private void TimerStop(bool isExpired)
    {
        var wasRunning = this.IsRunning;

        this.stopwatch.Stop();
        this.OnPropertyChanged(nameof(this.IsRunning));

        this.dispatcherTimer?.Stop();
        this.PercentageProgression = 100;

        // Avoid to raise event if the timer was already stopped
        if (wasRunning)
        {
            this.OnTimerStopped(isExpired);
        }
    }

    private void TimerTick(object? sender, EventArgs e)
    {
        MainThread.BeginInvokeOnMainThread(
            () =>
            {
                var elapsed = this.stopwatch.ElapsedMilliseconds;
                if (elapsed > (1000 * this.delayInSeconds))
                {
                    this.TimerStop(true);
                }
                else
                {
                    this.PercentageProgression = elapsed / 10f / this.delayInSeconds;
                }
            });
    }
}
