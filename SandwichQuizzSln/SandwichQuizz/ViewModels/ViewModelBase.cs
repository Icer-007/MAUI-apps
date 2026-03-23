using MauiCommons;
using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.ViewModels;

public partial class ViewModelBase : NotifyPropertyChangedBase
{
    protected readonly ILoggerService logger;

    public ViewModelBase(ILoggerService logger)
    {
        this.logger = logger;
        this.Title = string.Empty;
    }

    public bool IsBusy
    {
        get => this.GetValue<bool>();
        set
        {
            this.SetValue(value);
            this.OnPropertyChanged(nameof(this.IsNotBusy));
        }
    }

    public bool IsNotBusy => !this.IsBusy;

    public string? Title
    {
        get => this.GetValue<string>();
        set => this.SetValue(value);
    }
}
