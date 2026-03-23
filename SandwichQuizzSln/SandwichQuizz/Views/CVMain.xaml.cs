using SandwichQuizz.Extensions;

namespace SandwichQuizz.Views;

public partial class CVMain : ContentView
{
    public CVMain()
    {
        this.InitializeComponent();
    }

    public void Mute(bool isMute)
    {
        this.SetView.Mute(isMute);
    }

    protected async void BorderDrop(object sender, DropEventArgs e)
    {
        // Process the dropped file
        this.DropFileCommandContainer.ExecuteCommandIfCan(await e.DroppedFilePathAsync());
    }
}
