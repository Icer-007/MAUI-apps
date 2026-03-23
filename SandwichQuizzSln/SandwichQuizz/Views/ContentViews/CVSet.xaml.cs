namespace SandwichQuizz.Views.ContentViews;

public partial class CVSet : ContentView
{
    public CVSet()
    {
        this.InitializeComponent();
    }

    public void Mute(bool isMute)
    {
        this.MediaPlayer.ShouldMute = isMute;
    }
}
