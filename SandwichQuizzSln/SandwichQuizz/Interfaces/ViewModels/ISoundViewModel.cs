using MauiCommons;
using SandwichQuizz.Enums;

namespace SandwichQuizz.Interfaces.ViewModels;

public interface ISoundViewModel
{
    ICommandRaisable CommandPlay { get; }

    bool IsSoundEnabled { get; set; }

    string? Jingle { get; }

    void PlayLastRoundResult(bool isVictory);

    void PlayReaction(ReactionSound reaction);

    void PlayRound(Round round);

    void PlayTimeOver();

    void StopPlaying();
}
