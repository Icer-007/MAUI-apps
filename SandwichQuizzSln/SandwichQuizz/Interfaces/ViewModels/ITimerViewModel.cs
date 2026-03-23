using SandwichQuizz.Events;

namespace SandwichQuizz.Interfaces.ViewModels;

public interface ITimerViewModel
{
    event EventHandler<TimerStoppedEventArgs>? Stopped;

    bool IsRunning { get; }

    float PercentageProgression { get; }

    void Start(int delayInSeconds);

    void Stop();
}
