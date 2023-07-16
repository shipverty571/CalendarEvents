using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для EventManagementControl.
/// </summary>
public class EventsManagementVM : ObservableObject
{
    /// <summary>
    /// Заголовок.
    /// </summary>
    private string _title;

    /// <summary>
    /// Создает экземпляр класса <see cref="EventsManagementVM" />.
    /// </summary>
    /// <param name="dialogService">Сервис диалоговых окон.</param>
    /// <param name="eventStore">Хранилище задач.</param>
    /// <param name="calendarVM">ViewModel для CalendarControl.</param>
    public EventsManagementVM(
        IDialogService dialogService,
        EventStore eventStore,
        CalendarVM calendarVM)
    {
        DialogService = dialogService;
        EventStore = eventStore;
        CurrentDay = calendarVM.SelectedDay;
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
    }

    /// <summary>
    /// Возвращает и задает хранилище задач.
    /// </summary>
    public EventStore EventStore { get; set; }

    /// <summary>
    /// Возвращает и задает выбранный день.
    /// </summary>
    public CalendarDayVM CurrentDay { get; set; }

    /// <summary>
    /// Возвращает и задает сервис диалоговых окон.
    /// </summary>
    public IDialogService DialogService { get; set; }

    /// <summary>
    /// Возвращает команду добавления задачи.
    /// </summary>
    public RelayCommand AddEventCommand { get; }

    /// <summary>
    /// Возвращает команду отмены добавления задачи.
    /// </summary>
    public RelayCommand CloseCommand { get; }

    /// <summary>
    /// Возвращает и задает заголовок.
    /// </summary>
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    /// <summary>
    /// Добавляет задачу.
    /// </summary>
    private void AddEvent()
    {
        var dayEvent = new DayTask(Title);
        dayEvent.Date = CurrentDay.CalendarDay;
        EventStore.Add(dayEvent);
        Close();
    }

    /// <summary>
    /// Отменяет добавление задачи.
    /// </summary>
    private void Close()
    {
        Title = "";
        DialogService.Close();
    }
}