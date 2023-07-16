using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

/// <summary>
/// Сервис навигации пользовательских элементов управления.
/// </summary>
public class NavigationService : ObservableObject, INavigationService
{
    /// <summary>
    /// Фабрика для получения объекта ViewModel из коллекции сервисов.
    /// </summary>
    private readonly Func<Type, ObservableObject> _viewModelFactory;
    
    /// <summary>
    /// Текущий вид.
    /// </summary>
    private ObservableObject _currentView;

    /// <summary>
    /// Создает экземпляр класса <see cref="NavigationService"/>.
    /// </summary>
    /// <param name="viewModelFactory">Фабрика для получения объекта ViewModel из коллекции сервисов.</param>
    public NavigationService(Func<Type, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    /// <summary>
    /// Возвращает и задает текущий вид.
    /// </summary>
    public ObservableObject CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    /// <summary>
    /// Изменяет текущий вид на другой.
    /// </summary>
    /// <typeparam name="TViewModel">ViewModel вида, на который необходимо заменить.</typeparam>
    public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}