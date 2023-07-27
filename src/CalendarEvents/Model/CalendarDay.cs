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
    /// Создает экземпляр класса <see cref="CalendarDay"/>.
    /// </summary>
    public CalendarDay()
    {
        
    }

    /// <summary>
    /// Возвращает и задает дату.
    /// </summary>
    public DateOnly Date { get; set; }
    
    /// <summary>
    /// Возвращает и задает значение, указывающее, что день действительно входит в текущий месяц.
    /// </summary>
    public bool IsDateOfMonth { get; set; }
}