using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
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
    /// Создает экземпляр класса <see cref="MainVM" />.
    /// </summary>
    public MainVM()
    {
        CurrentDate = DateOnly.FromDateTime(DateTime.Now);
    }

    /// <summary>
    /// Возвращает и задает коллекцию дней в месяце.
    /// </summary>
    public ObservableCollection<CalendarDayVM> MonthDays { get; set; }

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
        }
    }

    /// <summary>
    /// Инициализирует коллекцию дней в месяце.
    /// </summary>
    private void SetMonthDays()
    {
        MonthDays = new ObservableCollection<CalendarDayVM>();
        for (var i = 0; i < (int)CurrentDate.DayOfWeek + 1; i++)
        {
            var day = new CalendarDayVM();
            day.IsDateOfMonth = false;
            MonthDays.Add(day);
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
}