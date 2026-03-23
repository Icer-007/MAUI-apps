using System.Windows.Input;

namespace MauiCommons.Extensions;

public static class ICommandExtensions
{
    extension(ICommand command)
    {
        public void ExecuteIfCan(object? param)
        {
            if (command?.CanExecute(param) is true)
                command.Execute(param);
        }
    }
}
