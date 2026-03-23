using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiCommons;

public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
{
    private readonly Dictionary<string, object?> propertyValueStorage;

    protected NotifyPropertyChangedBase()
    {
        this.propertyValueStorage = [];
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected T? GetValue<T>([CallerMemberName] string? propertyName = null)
    {
        return this.PrivGetValue<T>(propertyName!);
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void SetValue<T>(T value, [CallerMemberName] string? propertyName = null)
    {
        T? storedValue = this.PrivGetValue<T>(propertyName!);

        if (!object.Equals(storedValue, value))
        {
            this.propertyValueStorage[propertyName!] = value;
            this.OnPropertyChanged(propertyName!);
        }
    }

    protected bool SetValueWithCheck<T>(T value, [CallerMemberName] string? propertyName = null)
    {
        T? storedValue = this.PrivGetValue<T>(propertyName!);

        if (!object.Equals(storedValue, value))
        {
            this.propertyValueStorage[propertyName!] = value;
            this.OnPropertyChanged(propertyName!);
            return true;
        }

        return false;
    }

    private T? PrivGetValue<T>(string propertyName)
    {
        return this.propertyValueStorage.TryGetValue(propertyName, out object? value) ? (T)value! : default;
    }
}
