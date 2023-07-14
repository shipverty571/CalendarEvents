using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel.Services;

namespace ViewModel;

public class DayInfoVM : ObservableObject
{
    private int _date;
    
    private INavigationService _navigationService;

    private IDialogService _dialogService;
    
    public DayInfoVM(INavigationService navigationService, IDialogService dialogService, CalendarVM calendarVM)
    {
        NavigationService = navigationService;
        DialogService = dialogService;
        CalendarVM = calendarVM;
        BackToCalendarCommand = new RelayCommand(BackToCalendar);
        OpenEventsManagementCommand = new RelayCommand(OpenEventsManagement);
    }
    
    public CalendarVM CalendarVM { get; set; }
    
    public RelayCommand BackToCalendarCommand { get; }

    public RelayCommand OpenEventsManagementCommand { get;  }

    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetProperty(ref _navigationService, value);
    }

    public IDialogService DialogService
    {
        get => _dialogService;
        set => SetProperty(ref _dialogService, value);
    }
    
    private void BackToCalendar()
    {
        NavigationService.NavigateTo<CalendarVM>();
    }

    private void OpenEventsManagement()
    {
        DialogService.ShowDialog<EventsManagementVM>();
    }
}