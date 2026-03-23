namespace MauiCommons;

public class RelayCommand : ICommandRaisable
{
    private readonly Func<bool>? canExecuteAction;

    private readonly Func<object, bool>? canExecuteParamAction;

    private readonly Action? executeAction;

    private readonly Action<object>? executeParamAction;

    private readonly bool isParameterized;

    public RelayCommand(Action executeAction) : this(executeAction, null) { }

    public RelayCommand(Action executeAction, Func<bool>? canExecuteAction)
    {
        this.isParameterized = false;
        this.executeAction = executeAction;
        this.canExecuteAction = canExecuteAction;
    }

    public RelayCommand(Action<object> executeAction) : this(executeAction, null) { }

    public RelayCommand(Action<object> executeAction, Func<object, bool>? canExecuteAction)
    {
        this.isParameterized = true;
        this.executeParamAction = executeAction;
        this.canExecuteParamAction = canExecuteAction;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return this.isParameterized
               ? this.canExecuteParamAction == null || this.canExecuteParamAction.Invoke(parameter!)
               : this.canExecuteAction == null || this.canExecuteAction.Invoke();
    }

    public void Execute(object? parameter)
    {
        if (this.isParameterized)
        {
            if (this.CanExecute(parameter))
                this.executeParamAction?.Invoke(parameter!);
        }
        else
        {
            if (this.CanExecute(parameter))
                this.executeAction?.Invoke();
        }
    }

    public void RaiseCanExecuteChanged()
    {
        this.CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}
