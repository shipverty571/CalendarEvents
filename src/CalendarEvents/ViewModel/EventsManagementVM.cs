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
    /// <param name="eventRepository">Хранилище задач.</param>
    /// <param name="calendarVM">ViewModel для CalendarControl.</param>
    public EventsManagementVM(
        IDialogService dialogService,
        EventRepository eventRepository,
        DayInfoVM dayInfoVM)
    {
        DialogService = dialogService;
        EventRepository = eventRepository;
        IsEditable = dayInfoVM.IsEditable;
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
        BufferDayTask = dayInfoVM.SelectedTask;
        DayTask = new DayTask();
        DayTask.Date = dayInfoVM.CurrentDay.CalendarDay;
        // if (IsEditable)
        // {
        //     DayTask = (DayTask) BufferDayTask.Clone();
        // }
    }
    
    public DayTask BufferDayTask { get; set; }

    public DayTask DayTask { get; set; } 
    
    public bool IsEditable { get; }

    /// <summary>
    /// Возвращает и задает хранилище задач.
    /// </summary>
    public EventRepository EventRepository { get; set; }

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
    public string Title { get; set; }

    /// <summary>
    /// Добавляет задачу.
    /// </summary>
    private void AddEvent()
    {
        // if (IsEditable)
        // {
        //     EventRepository.Edit(BufferDayTask, DayTask);
        // }
        // else
        // {
        //     DayTask.Date = CurrentDay.CalendarDay;
        //     EventRepository.Add(DayTask);
        // }
        // Close();
        DayTask.Title = Title;
        EventRepository.Events.Add(DayTask);
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