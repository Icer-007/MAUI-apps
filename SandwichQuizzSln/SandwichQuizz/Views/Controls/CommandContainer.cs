using MauiCommons.Extensions;
using System.Windows.Input;

namespace SandwichQuizz.Views.Controls;

public partial class CommandContainer : ContentView
{
    public static readonly BindableProperty CommandProperty =
    BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(CommandContainer));

    public ICommand Command
    {
        get => (ICommand)this.GetValue(CommandProperty);
        set => this.SetValue(CommandProperty, value);
    }

    public void ExecuteCommandIfCan(object? commandParameter) => this.Command.ExecuteIfCan(commandParameter);
}
