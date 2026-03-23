using SandwichQuizz.Interfaces.Services;

namespace SandwichQuizz.Services;

public class LoggerService : ILoggerService
{
    private static readonly string DEFAULT_TITLE = "Attention";

    private static readonly string DEFAULT_CANCEL_CAPTION = "OK";

    public async Task PopMessageAsync(string message, string? title = null)
        => await Shell.Current.DisplayAlertAsync(title ?? DEFAULT_TITLE, message, DEFAULT_CANCEL_CAPTION);
}
