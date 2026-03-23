using MauiCommons;
using MauiCommons.Extensions;
using SandwichQuizz.Interfaces.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SandwichQuizz.ViewModels;

public partial class SetPropertiesViewModel : ViewModelBase
{
    private const int MAX_POINTS = 10;

    private const int MIN_POINTS = 1;

    public SetPropertiesViewModel(ILoggerService logger, int initialPoints) : base(logger)
    {
        this.SetPoints = [.. Enumerable.Range(0, initialPoints.Between(MIN_POINTS, MAX_POINTS))
                                       .Select(i => i % 2 != 0)];

        this.CommandDecreasePoints = new RelayCommand(() => this.UpdatePoints(false));
        this.CommandIncreasePoints = new RelayCommand(() => this.UpdatePoints(true));
    }

    public ICommand CommandDecreasePoints { get; }

    public ICommand CommandIncreasePoints { get; }

    public int Points => this.SetPoints.Count;

    public ObservableCollection<bool> SetPoints { get; }

    public void UpdatePoints(bool rise)
    {
        if (rise)
        {
            if (this.SetPoints.Count < MAX_POINTS)
            {
                this.SetPoints.Add(!this.SetPoints.LastOrDefault(true));
            }
        }
        else
        {
            if (this.SetPoints.Count > MIN_POINTS)
            {
                this.SetPoints.RemoveAt(this.SetPoints.Count - 1);
            }
        }

        this.OnPropertyChanged(nameof(this.Points));
    }
}
