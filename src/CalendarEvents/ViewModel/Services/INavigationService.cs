using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

/// <summary>
/// Интерфейс для сервиса навигации пользовательских элементов управления.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Возвращает и задает текущий вид.
    /// </summary>
    public ObservableObject CurrentView { get; set; }

    /// <summary>
    /// Изменяет текущий вид на другой.
    /// </summary>
    /// <typeparam name="TViewModel">ViewModel вида, на который необходимо заменить.</typeparam>
    public void NavigateTo<T>() where T : ObservableObject;
}