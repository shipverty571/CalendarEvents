namespace Model;

/// <summary>
/// Хранит информацию о событии.
/// </summary>
public class DayEvent
{
    /// <summary>
    /// Создает экземпляр класса <see cref="DayEvent" />.
    /// </summary>
    /// <param name="title">Имя события.</param>
    /// <param name="start">Время начала события события.</param>
    /// <param name="end">Время конца события события.</param>
    public DayEvent(string title, TimeOnly start, TimeOnly end)
    {
        Title = title;
        TimeOfStart = start;
        TimeOfEnd = end;
    }

    /// <summary>
    /// Возвращает и задает название события.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Возвращает и задает описание события.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Возвращает и задает время начала события.
    /// </summary>
    public TimeOnly TimeOfStart { get; set; }

    /// <summary>
    /// Возвращает и задает время конца события.
    /// </summary>
    public TimeOnly TimeOfEnd { get; set; }
}