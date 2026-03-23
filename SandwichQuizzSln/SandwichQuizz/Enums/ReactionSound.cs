using MauiCommons.Attributes;

namespace SandwichQuizz.Enums;

public enum ReactionSound
{
    [ResourceId("ReactionCorrect")]
    Right,

    [ResourceId("ReactionFaux")]
    Wrong,

    [ResourceId("ReactionPipeau")]
    Kidding,
}
