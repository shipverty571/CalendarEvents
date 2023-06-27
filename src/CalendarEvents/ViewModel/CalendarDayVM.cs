using CommunityToolkit.Mvvm.ComponentModel;
using Model;

namespace ViewModel;

/// <summary>
/// ViewModel для <see cref="CalendarDay" />.
/// </summary>
public class CalendarDayVM : ObservableObject
{
    /// <summary>
    /// Возвращает и задает день в календаре.
    /// </summary>
    public CalendarDay CalendarDay { get; set; }

    /// <summary>
    /// Возвращает и задает значение, указывающее, что день действительно входит в текущий месяц.
    /// </summary>
    public bool IsDateOfMonth { get; set; }
}