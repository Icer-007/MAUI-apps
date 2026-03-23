using SandwichQuizz.Extensions;
using SandwichQuizz.ViewModels;
using SandwichQuizz.Views;

namespace SandwichQuizz;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        this.BindingContext = viewModel;
        this.InitializeComponent();
    }

    private void BorderDoubleTapped(object sender, TappedEventArgs e)
    {
        Window? commandWindow = new Window(new PGCommandPopup { BindingContext = this.BindingContext });

        Application.Current?.OpenWindow(commandWindow);
    }

    private void GridDoubleTapped(object sender, TappedEventArgs e)
    {
        this.ToggleFullscreen();
    }
}
