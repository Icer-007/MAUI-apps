namespace SandwichQuizz.Views.ContentViews;

public partial class CVSound : ContentView
{
    public CVSound()
    {
        this.InitializeComponent();
    }

    private void SoundIconsTapped(object sender, TappedEventArgs e)
    {
        this.soundSwitch.IsToggled = object.ReferenceEquals(sender, this.unmute);
    }
}
