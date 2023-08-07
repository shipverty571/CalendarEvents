using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для CalendarControl.
/// </summary>
public class CalendarVM : ObservableObject
{
    /// <summary>
    /// Хранит количество дней в неделе.
    /// </summary>
    private const int MaxDaysOfWeek = 7;

    /// <summary>
    /// Текущая дата.
    /// </summary>
    private DateOnly _currentDate;

    /// <summary>
    /// Хранит экземпляр DayInfoVM.
    /// </summary>
    private DayInfoVM _currentDayInfoVM;

    /// <summary>
    /// Хранит значение, открывающее модальное окно для редактирования.
    /// </summary>
    private bool _isOpenDayInfo;

    /// <summary>
    /// Коллекция дней в месяце.
    /// </summary>
    private ObservableCollection<CalendarDay> _monthDays;

    /// <summary>
    /// Выбранный день.
    /// </summary>
    private CalendarDay _selectedDay;

    /// <summary>
    /// Создает экземпляр класса <see cref="CalendarVM" />.
    /// </summary>
    /// <param name="dialogService">Сервис диалоговых окон.</param>
    /// <param name="eventRepository">Хранилище задач.</param>
    /// <param name="viewModelFactory">Фабрика ViewModel.</param>
    public CalendarVM(
        IDialogService dialogService,
        EventRepository eventRepository,
        Func<Type, ObservableObject> viewModelFactory)
    {
        DialogService = dialogService;
        EventRepository = eventRepository;
        ViewModelFactory = viewModelFactory;
        CurrentDate = DateOnly.FromDateTime(DateTime.Now);
        SelectNextMonth = new RelayCommand(NextMonth);
        SelectPrevMonth = new RelayCommand(PrevMonth);
        CloseDayInfoCommand = new RelayCommand(CloseDayInfo);
    }

    /// <summary>
    /// Возвращает и задает экземпляр ViewModel.
    /// </summary>
    public Func<Type, ObservableObject> ViewModelFactory { get; set; }

    /// <summary>
    /// Возвращает и задает хранилище задач.
    /// </summary>
    public EventRepository EventRepository { get; set; }

    /// <summary>
    /// Возвращает и задает выбранный день.
    /// </summary>
    public CalendarDay SelectedDay
    {
        get => _selectedDay;
        set
        {
            _selectedDay = value;
            OnPropertyChanged();
            if (_selectedDay != null)
            {
                IsOpenDayInfo = true;
                var dayInfoVM = (DayInfoVM)ViewModelFactory.Invoke(typeof(DayInfoVM));
                dayInfoVM.CurrentDay = SelectedDay;
                CurrentDayInfoVM = dayInfoVM;
            }
        }
    }

    /// <summary>
    /// Возвращает и задает сервис диалоговых окон.
    /// </summary>
    public IDialogService DialogService { get; set; }

    /// <summary>
    /// Возвращает команду смены месяца на следующий.
    /// </summary>
    public RelayCommand SelectNextMonth { get; }

    /// <summary>
    /// Возвращает команду смены месяца на предыдущий.
    /// </summary>
    public RelayCommand SelectPrevMonth { get; }

    /// <summary>
    /// Возвращает команду закрытия диалогового окна.
    /// </summary>
    public RelayCommand CloseDayInfoCommand { get; }

    /// <summary>
    /// Возвращает и задает значение, открывающее модальное окно для редактирования.
    /// </summary>
    public bool IsOpenDayInfo
    {
        get => _isOpenDayInfo;
        set => SetProperty(ref _isOpenDayInfo, value);
    }

    /// <summary>
    /// Возвращает и задает экземпляр DayInfoVM.
    /// </summary>
    public DayInfoVM CurrentDayInfoVM
    {
        get => _currentDayInfoVM;
        set => SetProperty(ref _currentDayInfoVM, value);
    }

    /// <summary>
    /// Возвращает и задает коллекцию дней в месяце.
    /// </summary>
    public ObservableCollection<CalendarDay> MonthDays
    {
        get => _monthDays;
        set => SetProperty(ref _monthDays, value);
    }

    /// <summary>
    /// Возвращает и задает текущую дату.
    /// </summary>
    public DateOnly CurrentDate
    {
        get => _currentDate;
        set
        {
            _currentDate = value;
            SetMonthDays();
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// Инициализирует коллекцию дней в месяце.
    /// </summary>
    private void SetMonthDays()
    {
        MonthDays = new ObservableCollection<CalendarDay>();
        var startDayOfWeek =
            (int)new DateTime(CurrentDate.Year, CurrentDate.Month, 1).DayOfWeek;
        if (startDayOfWeek != MaxDaysOfWeek)
            for (var i = 1; i < startDayOfWeek; i++)
            {
                var day = new CalendarDay();
                day.IsDateOfMonth = false;
                day.HasTask = false;
                MonthDays.Add(day);
            }

        for (
            var date = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            date.Month == CurrentDate.Month;
            date = date.AddDays(1))
        {
            var day = new CalendarDay(date);
            day.IsDateOfMonth = true;
            day.HasTask = EventRepository.Get(day).Count > 0 ? true : false;
            MonthDays.Add(day);
        }
    }

    /// <summary>
    /// Меняет текущий месяц.
    /// </summary>
    /// <param name="count">Число, характеризующее, на какое количество месяцев изменить.</param>
    private void ChangeMonth(int count)
    {
        var changedMonth = CurrentDate.AddMonths(count);
        CurrentDate = changedMonth;
    }

    /// <summary>
    /// Изменяет текущий месяц на следующий.
    /// </summary>
    private void NextMonth()
    {
        ChangeMonth(1);
    }

    /// <summary>
    /// Изменяет текущий месяц на предыдущий.
    /// </summary>
    private void PrevMonth()
    {
        ChangeMonth(-1);
    }

    /// <summary>
    /// Закрывает модальное окно.
    /// </summary>
    private void CloseDayInfo()
    {
        IsOpenDayInfo = false;
        SelectedDay = null;
        CurrentDayInfoVM = null;
    }
}