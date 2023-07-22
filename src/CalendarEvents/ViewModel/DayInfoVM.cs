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
    /// Базовая высота диалогового окна для редактирования.
    /// </summary>
    private const int DialogHeight = 200;

    /// <summary>
    /// Базовая ширина диалогового окна для редактирования.
    /// </summary>
    private const int DialogWidth = 400;

    /// <summary>
    /// Хранит значение, указывающее, выбрана задача или нет.
    /// </summary>
    private bool _isSelected;

    /// <summary>
    /// Выбранная задача.
    /// </summary>
    private DayTask _selectedTask;

    private ObservableCollection<DayTask> _currentEvents;

    /// <summary>
    /// Создает экземпляр класса <see cref="DayInfoVM" />.
    /// </summary>
    /// <param name="navigationService">Сервис навигации пользовательских элементов управления.</param>
    /// <param name="dialogService">Сервис диалоговых окон.</param>
    /// <param name="eventRepository">Хранилище задач.</param>
    /// <param name="calendarVM">ViewModel для CalendarControl.</param>
    public DayInfoVM(INavigationService navigationService,
        IDialogService dialogService,
        EventRepository eventRepository,
        CalendarVM calendarVM)
    {
        NavigationService = navigationService;
        DialogService = dialogService;
        EventRepository = eventRepository;
        CurrentDay = calendarVM.SelectedDay;
        BackToCalendarCommand = new RelayCommand(BackToCalendar);
        OpenEventsManagementCommand = new RelayCommand(OpenEventsManagement);
        EditModeCommand = new RelayCommand(EditMode);
        CurrentEvents = EventRepository.Get(CurrentDay.CalendarDay);
        EventRepository.Events.CollectionChanged += EventRepository_CollectionChanged;
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
    /// Возвращает и задает текущий день.
    /// </summary>
    public CalendarDayVM CurrentDay { get; set; }

    /// <summary>
    /// Возвращает хранилище задач.
    /// </summary>
    public EventRepository EventRepository { get; }

    /// <summary>
    /// Возвращает команду для возврата на <see cref="CalendarVM" />.
    /// </summary>
    public RelayCommand BackToCalendarCommand { get; }

    /// <summary>
    /// Возвращает команду для вызова диалогового окна <see cref="EventsManagementVM" />.
    /// </summary>
    public RelayCommand OpenEventsManagementCommand { get; }
    
    public RelayCommand EditModeCommand { get; }

    public bool IsEditable { get; set; } = false;

    /// <summary>
    /// Возвращает и задает значение, указывающее, выбрана задача или нет.
    /// </summary>
    public bool IsSelected
    {
        get => _isSelected;
        set => SetProperty(ref _isSelected, value);
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
    /// Возвращает и задает сервис навигации пользовательских элементов управления.
    /// </summary>
    public INavigationService NavigationService { get; set; }

    /// <summary>
    /// Возвращает и задает сервис диалоговых окон.
    /// </summary>
    public IDialogService DialogService { get; set; }

    /// <summary>
    /// Выполняет возврат на <see cref="CalendarVM" />.
    /// </summary>
    private void BackToCalendar()
    {
        NavigationService.NavigateTo<CalendarVM>();
    }

    /// <summary>
    /// Открывает диалоговое окно <see cref="EventsManagementVM" />.
    /// </summary>
    private void OpenEventsManagement()
    {
        DialogService.Height = DialogHeight;
        DialogService.Width = DialogWidth;
        DialogService.ShowDialog<EventsManagementVM>();
    }

    private void EditMode()
    {
        IsEditable = true;
        OpenEventsManagement();
    }

    private void EventRepository_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        CurrentEvents = EventRepository.Get(CurrentDay.CalendarDay);
    }
}