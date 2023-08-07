using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для DayInfoControl.
/// </summary>
public class DayInfoVM : ObservableObject
{
    /// <summary>
    /// Базовая высота диалогового окна для удаления.
    /// </summary>
    private const int RemoveDialogHeight = 170;

    /// <summary>
    /// Базовая ширина диалогового окна для удаления.
    /// </summary>
    private const int RemoveDialogWidth = 300;

    /// <summary>
    /// Базовая высота диалогового окна для редактирования.
    /// </summary>
    private const int EditDialogHeight = 250;

    /// <summary>
    /// Базовая ширина диалогового окна для редактирования.
    /// </summary>
    private const int EditDialogWidth = 350;

    /// <summary>
    /// Коллекция задач.
    /// </summary>
    private ObservableCollection<DayTask> _currentEvents;

    /// <summary>
    /// Хранит значение, указывающее, выбрана задача или нет.
    /// </summary>
    private bool _isSelected;

    /// <summary>
    /// Выбранная задача.
    /// </summary>
    private DayTask _selectedTask;

    private CalendarDay _currentDay;

    /// <summary>
    /// Создает экземпляр класса <see cref="DayInfoVM" />.
    /// </summary>
    /// <param name="dialogService">Сервис диалоговых окон.</param>
    /// <param name="eventRepository">Хранилище задач.</param>
    /// <param name="viewModelFactory">Фабрика получения экземпляра ViewModel из коллекции сервисов.</param>
    public DayInfoVM(
        IDialogService dialogService,
        EventRepository eventRepository,
        Func<Type, ObservableObject> viewModelFactory)
    {
        DialogService = dialogService;
        EventRepository = eventRepository;
        ViewModelFactory = viewModelFactory;

        AddModeCommand = new RelayCommand(AddMode);
        EditModeCommand = new RelayCommand(EditMode);
        RemoveTaskCommand = new RelayCommand(RemoveTask);

        EventRepository.Events.CollectionChanged += EventRepository_CollectionChanged;
    }

    /// <summary>
    /// Возвращает и задает фабрику для получения экземпляра ViewModel из коллекции сервисов.
    /// </summary>
    public Func<Type, ObservableObject> ViewModelFactory { get; set; }

    /// <summary>
    /// Возвращает и задает текущий день.
    /// </summary>
    public CalendarDay CurrentDay
    {
        get => _currentDay;
        set
        {
            _currentDay = value;
            OnPropertyChanged();
            CurrentEvents = EventRepository.Get(CurrentDay);
        }
    }

    /// <summary>
    /// Возвращает хранилище задач.
    /// </summary>
    public EventRepository EventRepository { get; }

    /// <summary>
    /// Возвращает команду для добавления задачи.
    /// </summary>
    public RelayCommand AddModeCommand { get; }

    /// <summary>
    /// Возвращает команду для редактирования задачи.
    /// </summary>
    public RelayCommand EditModeCommand { get; }

    /// <summary>
    /// Возвращает команду для удаления задачи.
    /// </summary>
    public RelayCommand RemoveTaskCommand { get; }

    /// <summary>
    /// Возвращает и задает сервис диалоговых окон.
    /// </summary>
    public IDialogService DialogService { get; set; }

    /// <summary>
    /// Возвращает и задает значение, указывающее, выбрана задача или нет.
    /// </summary>
    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
    }

    /// <summary>
    /// Возвращает и задает задачи на текущий день.
    /// </summary>
    public ObservableCollection<DayTask> CurrentEvents
    {
        get => _currentEvents;
        private set => SetProperty(ref _currentEvents, value);
    }

    /// <summary>
    /// Возвращает и задает выбранную задачу.
    /// </summary>
    public DayTask SelectedTask
    {
        get => _selectedTask;
        set
        {
            _selectedTask = value;
            if (_selectedTask != null)
                IsSelected = true;
            else
                IsSelected = false;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Добавляет новую задачу.
    /// </summary>
    private void AddMode()
    {
        var eventsManagementViewModel =
            (EventsManagementVM)ViewModelFactory.Invoke(typeof(EventsManagementVM));
        eventsManagementViewModel.DayTask.Date = CurrentDay;

        DialogService.Height = EditDialogHeight;
        DialogService.Width = EditDialogWidth;
        var result = DialogService.ShowDialog(eventsManagementViewModel, "Add task");
        if (result != true) return;

        EventRepository.Events.Add(eventsManagementViewModel.DayTask);
    }

    /// <summary>
    /// Редактирует выбранную задачу.
    /// </summary>
    private void EditMode()
    {
        var eventsManagementViewModel =
            (EventsManagementVM)ViewModelFactory.Invoke(typeof(EventsManagementVM));
        eventsManagementViewModel.DayTask = (DayTask)SelectedTask.Clone();

        DialogService.Height = EditDialogHeight;
        DialogService.Width = EditDialogWidth;
        var result = DialogService.ShowDialog(eventsManagementViewModel, "Edit task");
        if (result != true) return;

        EventRepository.Edit(SelectedTask.Id, eventsManagementViewModel.DayTask);
    }

    /// <summary>
    /// Удаляет выбранную задачу.
    /// </summary>
    private void RemoveTask()
    {
        var messageViewModel = (MessageVM)ViewModelFactory.Invoke(typeof(MessageVM));
        messageViewModel.Text = "Do you really want to delete the task?";

        DialogService.Height = RemoveDialogHeight;
        DialogService.Width = RemoveDialogWidth;
        var result = DialogService.ShowDialog(messageViewModel, "Remove task");
        if (result != true) return;

        EventRepository.Remove(SelectedTask.Id);
    }

    private void EventRepository_CollectionChanged(object? sender,
        NotifyCollectionChangedEventArgs e)
    {
        CurrentEvents = EventRepository.Get(CurrentDay);
        CurrentDay.HasTask = CurrentEvents.Count > 0 ? true : false;
    }
}