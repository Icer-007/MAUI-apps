namespace SandwichQuizz.Extensions;

public static class ContentPageWindowsExtensions
{
    public static void ToggleFullscreen(this ContentPage contentPage)
    {
#if WINDOWS
        if (contentPage.GetAppWindow().Presenter is Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter)
        {
            if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
            {
                overlappedPresenter.SetBorderAndTitleBar(true, true);
                overlappedPresenter.Restore();
            }
            else
            {
                overlappedPresenter.SetBorderAndTitleBar(false, false);
                overlappedPresenter.Maximize();
            }
        }
#endif
    }

    public static void ToggleMaximizable(this ContentPage contentPage)
    {
#if WINDOWS
        if (contentPage.GetAppWindow().Presenter is Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter)
        {
            overlappedPresenter.IsMaximizable = !overlappedPresenter.IsMaximizable;
        }
#endif
    }

    public static void ToggleMinimizable(this ContentPage contentPage)
    {
#if WINDOWS
        if (contentPage.GetAppWindow().Presenter is Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter)
        {
            overlappedPresenter.IsMinimizable = !overlappedPresenter.IsMinimizable;
        }
#endif
    }

#if WINDOWS
    private static Microsoft.UI.Windowing.AppWindow GetAppWindow(this ContentPage contentPage)
    {
        var window = contentPage.GetParentWindow().Handler.PlatformView as MauiWinUIWindow;
        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
        return appWindow;
    }
#endif
}
