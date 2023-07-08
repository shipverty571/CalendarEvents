using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для окна MainWindow.
/// </summary>
public class MainVM : ObservableObject
{
    private INavigationService _navigationService;

    /// <summary>
    /// Создает экземпляр класса <see cref="MainVM" />.
    /// </summary>
    public MainVM(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.NavigateTo<CalendarVM>();
    }

    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetProperty(ref _navigationService, value);
    }
}