namespace Model;

/// <summary>
/// Хранит информацию о дне в календаре.
/// </summary>
public class CalendarDay
{
    /// <summary>
    /// Создает экземпляр класса <see cref="CalendarDay" />.
    /// </summary>
    /// <param name="date">Дата.</param>
    public CalendarDay(DateOnly date)
    {
        Date = date;
    }

    /// <summary>
    /// Возвращает и задает дату.
    /// </summary>
    public DateOnly Date { get; set; }
}