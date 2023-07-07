namespace Model;

/// <summary>
/// Хранит информацию о задаче.
/// </summary>
public class DayTask : IDayEvent
{
    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask"/>.
    /// </summary>
    /// <param name="title">Название.</param>
    public DayTask(string title)
    {
        Title = title;
        IsDone = false;
    }
    
    /// <summary>
    /// Возвращает и задает название события.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Хранит значение, указывающее, выполнена задача или нет.
    /// </summary>
    public bool IsDone { get; set; }
}