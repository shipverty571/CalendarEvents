using CommunityToolkit.Mvvm.ComponentModel;

namespace Model;

/// <summary>
/// Хранит информацию о дне в календаре.
/// </summary>
public class CalendarDay : ObservableObject
{
    private bool _hasTask;
    
    /// <summary>
    /// Создает экземпляр класса <see cref="CalendarDay" />.
    /// </summary>
    /// <param name="date">Дата.</param>
    public CalendarDay(DateTime date)
    {
        Date = date;
    }

    /// <summary>
    /// Создает экземпляр класса <see cref="CalendarDay" />.
    /// </summary>
    public CalendarDay()
    {
    }

    /// <summary>
    /// Возвращает и задает дату.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Возвращает и задает значение, указывающее, что день действительно входит в текущий месяц.
    /// </summary>
    public bool IsDateOfMonth { get; set; }

    /// <summary>
    /// Возвращает и задает значение, указывающее, есть ли задачи на этот день.
    /// </summary>
    public bool HasTask
    {
        get => _hasTask;
        set => SetProperty(ref _hasTask, value);
    }
}