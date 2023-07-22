using System.Collections.ObjectModel;

namespace Model;

public class RepositoryInMemory<T>
{
    private ObservableCollection<T> _events;

    public ObservableCollection<T> GetAll() => _events;
    
    public RepositoryInMemory()
    {
        _events = new ObservableCollection<T>();
    }

    public RepositoryInMemory(ObservableCollection<T> events)
    {
        _events = events;
    }
}