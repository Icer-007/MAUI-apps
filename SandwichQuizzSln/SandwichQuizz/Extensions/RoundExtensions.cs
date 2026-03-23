using SandwichQuizz.Enums;

namespace SandwichQuizz.Extensions;

public static class RoundExtensions
{
    public static bool IsConcurrent(this Round round)
        => round == Round.Round2 || round == Round.Round4;
}
