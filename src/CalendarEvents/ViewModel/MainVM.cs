using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel;

public class MainVM : ObservableObject
{
    private DateOnly _currentDate;
    
    public MainVM()
    {
        CurrentDate = DateOnly.FromDateTime(DateTime.Now);
    }

    private void SetMonthDays()
    {
        MonthDays = new ObservableCollection<CalendarDayVM>();
        for (int i = 0; i < (int)CurrentDate.DayOfWeek + 1; i++)
        {
            var day = new CalendarDayVM();
            MonthDays.Add(day);
        }
        for (
            var date = new DateTime(CurrentDate.Year, CurrentDate.Month, 1); 
            date.Month == CurrentDate.Month;
            date = date.AddDays(1))
        {
            var day = new CalendarDayVM();
            day.CalendarDay = new CalendarDay(DateOnly.FromDateTime(date));
            MonthDays.Add(day);
        }
    }

    public DateOnly CurrentDate
    {
        get
        {
            return _currentDate;
        }
        set
        {
            _currentDate = value;
            SetMonthDays();
        }
    }

    public ObservableCollection<CalendarDayVM> MonthDays { get; set; }
}