using CommunityToolkit.Mvvm.ComponentModel;

namespace Model;

/// <summary>
/// Хранит информацию о задаче.
/// </summary>
public class DayTask : ObservableObject, ICloneable
{
    /// <summary>
    /// Хранит количество всех созданных задач.
    /// </summary>
    private static int _allTasksCount;

    /// <summary>
    /// Заголовок.
    /// </summary>
    private string _title;

    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask" />.
    /// </summary>
    /// <param name="title">Название.</param>
    public DayTask(string title)
    {
        Title = title;
        _allTasksCount++;
        Id = _allTasksCount;
    }

    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask"/>.
    /// </summary>
    public DayTask()
    {
        _allTasksCount++;
        Id = _allTasksCount;
    }

    /// <summary>
    /// Возвращает уникальный идентификатор.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Возвращает и задает название события.
    /// </summary>
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    /// <summary>
    /// Возвращает и задает значение, указывающее, выполнена задача или нет.
    /// </summary>
    public bool IsDone { get; set; } = false;

    /// <summary>
    /// Возвращает и задает день.
    /// </summary>
    public CalendarDay Date { get; set; }

    /// <summary>
    /// Производит клонирование текущего экземпляра.
    /// </summary>
    /// <returns>Возвращает клон текущего экземпляра.</returns>
    public object Clone()
    {
        return new DayTask(Title);
    }
}