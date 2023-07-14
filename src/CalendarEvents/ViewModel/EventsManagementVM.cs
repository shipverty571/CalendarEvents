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

    public EventsManagementVM(DayInfoVM dayInfoVM, IDialogService dialogService)
    {
        DayInfoVM = dayInfoVM;
        DialogService = dialogService;
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
    }

    public IDialogService DialogService
    {
        get => _dialogService;
        set => SetProperty(ref _dialogService, value);
    }

    public DayInfoVM DayInfoVM
    {
        get => _dayInfoVM;
        set => SetProperty(ref _dayInfoVM, value);
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
        IDayEvent dayEvent = new DayTask(Title);
        DayInfoVM.CalendarVM.SelectedDay.CalendarDay.DayEvents.Add(dayEvent);
        Title = "";
        DialogService.Close();
    }

    private void Close()
    {
        Title = "";
        DialogService.Close();
    }
}