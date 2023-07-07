namespace Model;

/// <summary>
/// Хранит информацию о событии.
/// </summary>
public class DayActivity : IDayEvent
{
    /// <summary>
    /// Создает экземпляр класса <see cref="DayActivity" />.
    /// </summary>
    /// <param name="title">Имя события.</param>
    /// <param name="start">Время начала события события.</param>
    public DayActivity(string title, TimeOnly start)
    {
        Title = title;
        TimeStart = start;
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
    public TimeOnly TimeStart { get; set; }
}