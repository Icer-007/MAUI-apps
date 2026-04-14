using SandwichQuizz.Extensions;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.ViewModels;
using SandwichQuizz.Views;

namespace SandwichQuizz;

public partial class MainPage : ContentPage
{
    private readonly IWindowService windowService;

    public MainPage(IWindowService windowService, MainViewModel viewModel)
    {
        this.windowService = windowService;
        this.BindingContext = viewModel;

        this.InitializeComponent();
    }

    private void BackgroundGridDoubleTapped(object sender, TappedEventArgs e)
    {
        this.ToggleFullscreen();
    }

    private void MirrorModeBorderDoubleTapped(object sender, TappedEventArgs e)
    {
        this.windowService.ShowWindow<PGCommandPopup>();
    }
}
