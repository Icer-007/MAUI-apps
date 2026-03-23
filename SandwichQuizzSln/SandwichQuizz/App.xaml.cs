namespace SandwichQuizz;

public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
        MauiExceptions.UnhandledException += this.App_UnhandledException;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    private void App_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        // Process unhandled exception
        Shell.Current.DisplayAlertAsync("Unexpected exception", e.ExceptionObject.ToString(), "Close");
    }
}