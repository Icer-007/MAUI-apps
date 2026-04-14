using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.Services;

public class WindowService : IWindowService
{
    public void ShowWindow<T>() where T : Page
    {
        if (Application.Current is not null
            && DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            if (IPlatformApplication.Current?.Services.GetService<T>() is Page page)
            {
                if (Application.Current
                               .Windows
                               .FirstOrDefault(w => object.ReferenceEquals(w.Page, page))
                               is Window currentWindow)
                    Application.Current.ActivateWindow(currentWindow);
                else
                    Application.Current.OpenWindow(new Window(page));
            }
        }
    }
}
