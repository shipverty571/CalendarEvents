using System.Collections.ObjectModel;

namespace Model;

/// <summary>
/// Класс с тестовыми данными для отладки.
/// </summary>
public static class TestData
{
    /// <summary>
    /// Генерирует коллекцию задач.
    /// </summary>
    /// <returns>Возвращает коллекцию задач.</returns>
    public static ObservableCollection<DayTask> DayTasks()
    {
        var dayTasks = new ObservableCollection<DayTask>();
        for (var i = 0; i < 10; i++)
        {
            var task = new DayTask();
            task.Title = $"Task {task.Id}";
            task.Date = new CalendarDay(DateOnly.FromDateTime(DateTime.Today));
            dayTasks.Add(task);
        }

        return dayTasks;
    }
}