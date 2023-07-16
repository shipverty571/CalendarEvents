using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для окна MainWindow.
/// </summary>
public class MainVM : ObservableObject
{
    /// <summary>
    /// Создает экземпляр класса <see cref="MainVM" />.
    /// </summary>
    /// <param name="navigationService">Сервис навигации пользовательских элементов управления.</param>
    public MainVM(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.NavigateTo<CalendarVM>();
    }

    /// <summary>
    /// Возвращает и задает сервис навигации пользовательских элементов управления.
    /// </summary>
    public INavigationService NavigationService { get; set; }
}