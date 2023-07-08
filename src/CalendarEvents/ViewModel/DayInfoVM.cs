using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel.Services;

namespace ViewModel;

public class DayInfoVM : ObservableObject
{
    private int _date;
    
    private INavigationService _navigationService;
    
    public DayInfoVM(INavigationService navigationService, CalendarVM calendarVM)
    {
        CalendarVM = calendarVM;
        NavigationService = navigationService;
        BackToCalendarCommand = new RelayCommand(BackToCalendar);
    }
    
    public CalendarVM CalendarVM { get; }
    
    public INavigationService NavigationService
    {
        get => _navigationService;
        set => SetProperty(ref _navigationService, value);
    }

    public int DateNumber
    {
        get => CalendarVM.SelectedDay.CalendarDay.Date.Day;
    }
    
    public RelayCommand BackToCalendarCommand { get; }

    private void BackToCalendar()
    {
        NavigationService.NavigateTo<CalendarVM>();
    }
}