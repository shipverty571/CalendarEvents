using System.Collections.ObjectModel;

namespace Model;

public class EventStore
{
    private CalendarDay _currentDay;
    
    public ObservableCollection<DayTask> Events { get; set; }

    public EventStore()
    {
        Events = new ObservableCollection<DayTask>();
    }

    public void Add(DayTask dayEvent)
    {
        Events.Add(dayEvent);
    }
}