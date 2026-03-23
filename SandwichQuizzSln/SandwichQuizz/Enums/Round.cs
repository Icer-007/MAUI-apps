using MauiCommons.Attributes;

namespace SandwichQuizz.Enums;

public enum Round
{
    [Description("Round0")]
    Round0 = 0,

    [Description("Round1")]
    Round1 = 1,

    [Description("Round2")]
    Round2,

    [Description("Round3")]
    Round3,

    [Description("Round4")]
    Round4,

    [Description("Sandwich de la mort")]
    Round5,
}
