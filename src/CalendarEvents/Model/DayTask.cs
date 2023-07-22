using CommunityToolkit.Mvvm.ComponentModel;

namespace Model;

/// <summary>
/// Хранит информацию о задаче.
/// </summary>
public class DayTask : ObservableObject, ICloneable
{
    private static int _allTasksCount;

    private readonly int _id;
    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask"/>.
    /// </summary>
    /// <param name="title">Название.</param>
    public DayTask(string title)
    {
        Title = title;
        _allTasksCount++;
        _id = _allTasksCount;
    }

    public DayTask()
    {
        _allTasksCount++;
        _id = _allTasksCount;
    }

    public int Id => _id;

    /// <summary>
    /// Возвращает и задает название события.
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Хранит значение, указывающее, выполнена задача или нет.
    /// </summary>
    public bool IsDone { get; set; } = false;

    public CalendarDay Date { get; set; }

    public object Clone()
    {
        return new DayTask(Title);
    }
}