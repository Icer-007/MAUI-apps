using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SandwichQuizz.Factories;
using SandwichQuizz.Interfaces.Factories;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.Utils;
using SandwichQuizz.Interfaces.ViewModels;
using SandwichQuizz.Services;
using SandwichQuizz.Utils;
using SandwichQuizz.ViewModels;

namespace SandwichQuizz;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkitMediaElement(false)
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Rubik-Regular.ttf", "Rubik-Regular");
                fonts.AddFont("Merienda-Regular.ttf", "Merienda-Regular");
                fonts.AddFont("comic.ttf", "Comic-Sans-MS");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<ILoggerService, LoggerService>();
        builder.Services.AddSingleton<ISettingsService, SettingsService>();
        builder.Services.AddSingleton<ITimerViewModel, TimerViewModel>();
        builder.Services.AddSingleton<ISoundViewModel, SoundViewModel>();
        builder.Services.AddSingleton<IViewModelFactory, ViewModelFactory>();

        builder.Services.AddSingleton<IBaseInjection, BaseInjection>();
        builder.Services.AddSingleton<IViewModelInjection, ViewModelInjection>();

        builder.Services.AddSingleton<MainViewModel>();

        return builder.Build();
    }
}
