using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

public class DayInfoVM : ObservableObject
{
    private const int DialogHeight = 200;

    private const int DialogWidth = 400;

    private IDialogService _dialogService;

    private INavigationService _navigationService;

    private ObservableCollection<DayTask> _currentEvents;

    public DayInfoVM(INavigationService navigationService,
        IDialogService dialogService,
        EventStore eventStore,
        CalendarVM calendarVM)
    {
        NavigationService = navigationService;
        DialogService = dialogService;
        EventStore = eventStore;
        CalendarVM = calendarVM;
        CurrentEvents = new ObservableCollection<DayTask>();
        BackToCalendarCommand = new RelayCommand(BackToCalendar);
        OpenEventsManagementCommand = new RelayCommand(OpenEventsManagement);
        EventStore.Events.CollectionChanged += EventStore_CollectionChanged;
        UpdateCurrentEvents();
    }
    
    public CalendarVM CalendarVM { get; }

    public ObservableCollection<DayTask> CurrentEvents
    {
        get => _currentEvents;
        set => SetProperty(ref _currentEvents, value);
    }

    public CalendarDayVM CurrentDay
    {
        get => CalendarVM.SelectedDay;
    }

    public EventStore EventStore { get; set; }

    public RelayCommand BackToCalendarCommand { get; }

    public RelayCommand OpenEventsManagementCommand { get; }

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
        DialogService.Height = DialogHeight;
        DialogService.Width = DialogWidth;
        DialogService.ShowDialog<EventsManagementVM>();
    }

    public void UpdateCurrentEvents()
    {
        var events = EventStore.Events.Where(dayEvent => dayEvent.Date.Date == CurrentDay.CalendarDay.Date);
        CurrentEvents.Clear();
        events.ToList().ForEach(CurrentEvents.Add);
    }
    
    private void EventStore_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        UpdateCurrentEvents();
    }
}