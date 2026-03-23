using System.Windows.Input;

namespace MauiCommons;

public interface ICommandRaisable : ICommand
{
    void RaiseCanExecuteChanged();
}
