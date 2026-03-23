namespace SandwichQuizz.Events;

public class TimerStoppedEventArgs(bool isExpired) : EventArgs
{
    public bool IsExpired { get; set; } = isExpired;
}
