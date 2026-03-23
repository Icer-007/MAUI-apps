using MauiCommons;
using MauiCommons.Attributes;
using MauiCommons.Extensions;
using SandwichQuizz.Enums;
using SandwichQuizz.Interfaces.Services;
using SandwichQuizz.Interfaces.ViewModels;

namespace SandwichQuizz.ViewModels;

public partial class SoundViewModel : ViewModelBase, ISoundViewModel
{
    private const string JINGLENAME_BASE__SET_NB = "Sounds/JingleSet0{0}.mp3";

    private const string JINGLENAME_NOSOUND = "Sounds/muter.mp3";

    private const string LASTROUNDRESULT_FAILED = "Sounds/Round5Perdu.mp3";

    private const string LASTROUNDRESULT_VICTORY = "Sounds/Round5Reussi.mp3";

    private const string REACTION_BASE__FILENAME = "Sounds/{0}.mp3";

    private const string TIME_OVER = "Sounds/TempsDepasse.mp3";

    public SoundViewModel(ILoggerService logger) : base(logger)
    {
        this.CommandPlay = new RelayCommand(this.Play, p => this.IsSoundEnabled);

        this.IsSoundEnabled = true;
    }

    public ICommandRaisable CommandPlay { get; }

    public bool IsSoundEnabled
    {
        get => this.GetValue<bool>();
        set
        {
            this.SetValue(value);
            if (!this.IsSoundEnabled)
            {
                this.StopPlaying();
            }
            this.CommandPlay.RaiseCanExecuteChanged();
        }
    }

    public string? Jingle
    {
        get => this.GetValue<string>();
        private set => this.SetValue(value is null || !this.IsSoundEnabled ? JINGLENAME_NOSOUND : value);
    }

    public void PlayLastRoundResult(bool isVictory)
        => this.PlayResource(isVictory ? LASTROUNDRESULT_VICTORY : LASTROUNDRESULT_FAILED);

    public void PlayReaction(ReactionSound reaction)
        => this.PlayResource(string.Format(REACTION_BASE__FILENAME, reaction.GetField().GetAttributeStringValue<ResourceIdAttribute>()));

    public void PlayRound(Round round)
        => this.PlayResource(string.Format(JINGLENAME_BASE__SET_NB, (int)round));

    public void PlayTimeOver()
        => this.PlayResource(TIME_OVER);

    public void StopPlaying()
    {
        this.Jingle = null;
    }

    private void Play(object param)
    {
        if (param is ReactionSound reaction)
        {
            this.PlayReaction(reaction);
        }
    }

    private void PlayResource(string resId)
    {
        // To reset current playing
        this.StopPlaying();

        this.Jingle = resId;
    }
}
