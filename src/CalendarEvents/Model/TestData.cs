using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace Model;

public static class TestData
{
    public static ObservableCollection<DayTask> DayTasks()
    {
        ObservableCollection<DayTask> dayTasks = new ObservableCollection<DayTask>();
        for (int i = 0; i < 10; i++)
        {
            var task = new DayTask();
            task.Title = $"Task {task.Id}";
            task.Date = new CalendarDay(DateOnly.FromDateTime(DateTime.Today));
            dayTasks.Add(task);
        }

        return dayTasks;
    }
}