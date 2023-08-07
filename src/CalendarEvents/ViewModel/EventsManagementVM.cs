using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using Model.Enums;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для EventManagementControl.
/// </summary>
public class EventsManagementVM : ObservableValidator, IDialogResultVMHelper
{
    /// <summary>
    /// Минимальное количество символов в заголовке.
    /// </summary>
    private const int MinLengthText = 1;

    /// <summary>
    /// Максимальное количество символов в заголовке.
    /// </summary>
    private const int MaxLengthText = 100;
    
    /// <summary>
    /// Создает экземпляр класса <see cref="EventsManagementVM" />.
    /// </summary>
    /// <param name="eventRepository">Хранилище задач.</param>
    public EventsManagementVM(EventRepository eventRepository)
    {
        EventRepository = eventRepository;

        var colorDesctiptions = typeof(Colors).GetMembers()
            .SelectMany(member => member.GetCustomAttributes(typeof (DescriptionAttribute), true).Cast<DescriptionAttribute>())
            .ToList();
        Colors = colorDesctiptions.Select(color => color.Description).ToList();
        Title = "";
        
        AddEventCommand = new RelayCommand(AddEvent);
        CloseCommand = new RelayCommand(Close);
    }

    /// <summary>
    /// Возвращает и задает коллекцию задач.
    /// </summary>
    public List<string> Colors { get; set; }

    /// <summary>
    /// Возвращает и задает задачу.
    /// </summary>
    public DayTask DayTask { get; set; } = new();

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
    [MinLength(MinLengthText, ErrorMessage = $"The number of characters must be at least 1")]
    [MaxLength(MaxLengthText, ErrorMessage = $"The number of characters should not exceed 100")]
    public string Title
    {
        get => DayTask.Title;
        set => SetProperty(
            DayTask.Title,
            value,
            DayTask,
            (task, title) => DayTask.Title = title,
            true);
    }

    /// <summary>
    /// Возвращает и задает цвет.
    /// </summary>
    public string Color
    {
        get => DayTask.Color;
        set => SetProperty(
            DayTask.Color,
            value,
            DayTask,
            (task, color) => DayTask.Color = color);
    }

    /// <summary>
    /// Возвращает и задает статус выполнения задачи.
    /// </summary>
    public bool IsDone
    {
        get => DayTask.IsDone;
        set => SetProperty(
            DayTask.IsDone,
            value,
            DayTask,
            (task, isDone) => DayTask.IsDone = isDone);
    }

    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;

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

    private void InvokeRequestCloseDialog(RequestCloseDialogEventArgs e)
    {
        RequestCloseDialog.Invoke(this, e);
    }
}