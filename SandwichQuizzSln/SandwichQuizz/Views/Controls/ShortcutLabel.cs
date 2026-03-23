using MauiCommons;
using MauiCommons.Enums;
using MauiCommons.Extensions;
using System.Windows.Input;

namespace SandwichQuizz.Views.Controls;

public partial class ShortcutLabel : Label
{
    public static readonly BindableProperty AvailableShortcutsProperty =
        BindableProperty.Create(
            nameof(AvailableShortcuts),
            typeof(IEnumerable<WindowsSystemVirtualKey>),
            typeof(ShortcutLabel),
            defaultBindingMode: BindingMode.OneWay,
            propertyChanged: OnConfigChanged);

    public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(ShortcutLabel),
            propertyChanged: OnConfigChanged);

    private readonly ICommand internalCommand;

    public ShortcutLabel()
    {
        this.internalCommand = new RelayCommand(p => this.Command.ExecuteIfCan(p));
    }

    ~ShortcutLabel()
    {
        this.SetUpMenuFlyout(true);
    }

    public IEnumerable<WindowsSystemVirtualKey> AvailableShortcuts
    {
        get => (IEnumerable<WindowsSystemVirtualKey>)this.GetValue(AvailableShortcutsProperty);
        set => this.SetValue(AvailableShortcutsProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)this.GetValue(CommandProperty);
        set => this.SetValue(CommandProperty, value);
    }

    private static void OnConfigChanged(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as ShortcutLabel)?.SetUpMenuFlyout(false);
    }

    private MenuFlyoutItem BuildMenuFlyoutItem(
        WindowsSystemVirtualKey key,
        KeyboardAcceleratorModifiers modifier = KeyboardAcceleratorModifiers.None)
    {
        var res = new MenuFlyoutItem { Command = this.internalCommand, CommandParameter = key, };
        res.KeyboardAccelerators.Add(new KeyboardAccelerator { Modifiers = modifier, Key = key.ToString() });

        return res;
    }

    private void SetUpMenuFlyout(bool cleanUpOnly)
    {
        // Clean up
        if (FlyoutBase.GetContextFlyout(this) is MenuFlyout oldShortCuts)
        {
            FlyoutBase.SetContextFlyout(this, null);
            foreach (MenuFlyoutItem shortcut in oldShortCuts.OfType<MenuFlyoutItem>().ToArray())
                shortcut.Command = null;
            oldShortCuts.Clear();
        }

        // Set up
        if (!cleanUpOnly
            && this.Command is not null
            && this.AvailableShortcuts?.Any() is true)
        {
            var newShortCuts = new MenuFlyout();
            foreach (var item in this.AvailableShortcuts.ToArray())
                newShortCuts.Add(this.BuildMenuFlyoutItem(item));

            FlyoutBase.SetContextFlyout(this, newShortCuts);
        }
    }
}
