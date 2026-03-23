namespace SandwichQuizz.Interfaces.Services;

public interface ILoggerService
{
    Task PopMessageAsync(string message, string? title = null);
}
