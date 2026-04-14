using SandwichQuizz.ViewModels;

namespace SandwichQuizz.Views;

public partial class PGCommandPopup : ContentPage
{
    public PGCommandPopup(MainViewModel viewModel)
    {
        this.BindingContext = viewModel;

        this.InitializeComponent();
        this.MainView.Mute(true);
    }
}
