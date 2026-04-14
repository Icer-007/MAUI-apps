namespace SandwichQuizz.Interfaces.Services;

public interface IWindowService
{
    void ShowWindow<T>() where T : Page;
}
