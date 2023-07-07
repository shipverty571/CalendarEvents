using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel;

/// <summary>
/// ViewModel для окна MainWindow.
/// </summary>
public class MainVM : ObservableObject
{
    /// <summary>
    /// Текущая дата.
    /// </summary>
    private DateOnly _currentDate;

    /// <summary>
    /// Коллекция дней в месяце.
    /// </summary>
    private ObservableCollection<CalendarDayVM> _monthDays;

    /// <summary>
    /// Создает экземпляр класса <see cref="MainVM" />.
    /// </summary>
    public MainVM()
    {
        CurrentDate = DateOnly.FromDateTime(DateTime.Now);
        SelectNextMonth = new RelayCommand(NextMonth);
        SelectPrevMonth = new RelayCommand(PrevMonth);
    }

    /// <summary>
    /// Возвращает и задает коллекцию дней в месяце.
    /// </summary>
    public ObservableCollection<CalendarDayVM> MonthDays
    {
        get => _monthDays;
        set => SetProperty(ref _monthDays, value);
    }
    
    /// <summary>
    /// Возвращает команду смены месяца на следующий.
    /// </summary>
    public RelayCommand SelectNextMonth { get; }
    
    /// <summary>
    /// Возвращает команду смены месяца на предыдущий.
    /// </summary>
    public RelayCommand SelectPrevMonth { get; }

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
        MonthDays = new ObservableCollection<CalendarDayVM>();
        var startDayOfWeek = (int)CurrentDate.DayOfWeek;
        if (startDayOfWeek != 7)
        {
            for (var i = 0; i < startDayOfWeek; i++)
            {
                var day = new CalendarDayVM();
                day.IsDateOfMonth = false;
                MonthDays.Add(day);
            }
        }
        
        for (
            var date = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            date.Month == CurrentDate.Month;
            date = date.AddDays(1))
        {
            var day = new CalendarDayVM();
            day.CalendarDay = new CalendarDay(DateOnly.FromDateTime(date));
            day.IsDateOfMonth = true;
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
}