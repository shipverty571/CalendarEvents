﻿using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Model.Enums;

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
    /// Цвет.
    /// </summary>
    private string _color;

    /// <summary>
    /// Статус.
    /// </summary>
    private bool _isDone;

    /// <summary>
    /// Заголовок.
    /// </summary>
    private string _title;

    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask" />.
    /// </summary>
    /// <param name="title">Название.</param>
    /// <param name="date">Дата.</param>
    /// <param name="isDone">Статус.</param>
    /// <param name="color">Цвет.</param>
    public DayTask(string title, CalendarDay date, bool isDone, string color)
    {
        Title = title;
        Date = date;
        IsDone = isDone;
        Color = color;
        _allTasksCount++;
        Id = _allTasksCount;
    }

    /// <summary>
    /// Создает экземпляр класса <see cref="DayTask" />.
    /// </summary>
    public DayTask()
    {
        _allTasksCount++;
        Id = _allTasksCount;
        var color = Colors.Base;
        Color = (color.GetType().GetMember(color.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)[0] as
            DescriptionAttribute).Description;
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
    public bool IsDone
    {
        get => _isDone;
        set => SetProperty(ref _isDone, value);
    }

    /// <summary>
    /// Возвращает и задает день.
    /// </summary>
    public CalendarDay Date { get; set; }

    /// <summary>
    /// Возвращает и задает цвет задачи.
    /// </summary>
    public string Color
    {
        get => _color;
        set => SetProperty(ref _color, value);
    }

    /// <summary>
    /// Производит клонирование текущего экземпляра.
    /// </summary>
    /// <returns>Возвращает клон текущего экземпляра.</returns>
    public object Clone()
    {
        return new DayTask(Title, Date, IsDone, Color);
    }
}