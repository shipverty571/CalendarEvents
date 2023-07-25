using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для EventManagementControl.
/// </summary>
public class EventsManagementVM : ObservableObject, IDialogResultVMHelper
{
    /// <summary>
    /// Создает экземпляр класса <see cref="EventsManagementVM" />.
    /// </summary>
    /// <param name="eventRepository">Хранилище задач.</param>
    public EventsManagementVM(EventRepository eventRepository)
    {
        EventRepository = eventRepository;
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
    }

    public DayTask DayTask { get; set; } = new DayTask();

    /// <summary>
    /// Возвращает и задает хранилище задач.
    /// </summary>
    public EventRepository EventRepository { get; set; }

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
        get => DayTask.Title;
        set => SetProperty(
            DayTask.Title, 
            value, 
            DayTask, 
            (task, title) => DayTask.Title = title);
    }

    /// <summary>
    /// Добавляет задачу.
    /// </summary>
    private void AddEvent()
    {
        InvokeRequestCloseDialog(
            new RequestCloseDialogEventArgs(true));
    }

    /// <summary>
    /// Отменяет добавление задачи.
    /// </summary>
    private void Close()
    {
        InvokeRequestCloseDialog(
            new RequestCloseDialogEventArgs(false));
    }
    
    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
    
    private void InvokeRequestCloseDialog(RequestCloseDialogEventArgs e)
    {
        var handler = RequestCloseDialog;
        if (handler != null) 
            handler(this, e);
    }
}