using System.Collections.ObjectModel;

namespace Model;

public class EventRepository : RepositoryInMemory<DayTask>
{
    public EventRepository() : base(TestData.DayTasks())
    {
        
    }
    
    public ObservableCollection<DayTask> Events => GetAll();

    public ObservableCollection<DayTask> Get(CalendarDay calendarDay)
    {
        var events = Events.Where(day => day.Date.Date == calendarDay.Date);
        return new ObservableCollection<DayTask>(events);
    }

    public void Edit(int id, DayTask task)
    {
        var editableObjectIndexOf = Events.IndexOf(Events.First(dayTask => dayTask.Id == id));
        Events[editableObjectIndexOf].Title = task.Title;
    }

    public void Remove(int id)
    {
        var item = Events.First(task => task.Id == id);
        Events.Remove(item);
    }
}