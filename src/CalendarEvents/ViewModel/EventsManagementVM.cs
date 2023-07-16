using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

public class EventsManagementVM : ObservableObject
{
    private string _title;

    private DayInfoVM _dayInfoVM;

    private IDialogService _dialogService;

    public EventsManagementVM(IDialogService dialogService, EventStore eventStore, CalendarVM calendarVM)
    {
        DialogService = dialogService;
        EventStore = eventStore;
        CalendarVM = calendarVM;
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
    }
    
    public EventStore EventStore { get; set; }
    
    public CalendarVM CalendarVM { get; set; }

    public IDialogService DialogService
    {
        get => _dialogService;
        set => SetProperty(ref _dialogService, value);
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
    
    public RelayCommand AddEventCommand { get; }
    
    public RelayCommand CloseCommand { get; }

    private void AddEvent()
    {
        var dayEvent = new DayTask(Title);
        dayEvent.Date = CalendarVM.SelectedDay.CalendarDay;
        EventStore.Add(dayEvent);
        Title = "";
        DialogService.Close();
    }

    private void Close()
    {
        Title = "";
        DialogService.Close();
    }
}