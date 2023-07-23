using System.Collections.ObjectModel;

namespace Model;

/// <summary>
/// Хранилище задач.
/// </summary>
public class EventRepository : RepositoryInMemory<DayTask>
{
    /// <summary>
    /// Создает экземпляр класса <see cref="EventRepository"/>.
    /// </summary>
    public EventRepository() : base(TestData.DayTasks())
    {
    }

    /// <summary>
    /// Возвращает коллекцию со всеми задачами.
    /// </summary>
    public ObservableCollection<DayTask> Events => GetAll();

    /// <summary>
    /// Получение задач на определенный день.
    /// </summary>
    /// <param name="calendarDay">День.</param>
    /// <returns>Возвращает коллекцию задач.</returns>
    public ObservableCollection<DayTask> Get(CalendarDay calendarDay)
    {
        var events = Events.Where(day => day.Date.Date == calendarDay.Date);
        return new ObservableCollection<DayTask>(events);
    }

    /// <summary>
    /// Редактирует задачу.
    /// </summary>
    /// <param name="id">Уникальный идентификатор задачи, которую нужно редактировать.</param>
    /// <param name="task">Задача с данными для редактирования.</param>
    public void Edit(int id, DayTask task)
    {
        var editableObjectIndexOf = Events.IndexOf(Events.First(dayTask => dayTask.Id == id));
        Events[editableObjectIndexOf].Title = task.Title;
    }

    /// <summary>
    /// Удаляет задачу.
    /// </summary>
    /// <param name="id">Уникальный идентификатор задачи, которую нужно удалить.</param>
    public void Remove(int id)
    {
        var item = Events.First(task => task.Id == id);
        Events.Remove(item);
    }
}