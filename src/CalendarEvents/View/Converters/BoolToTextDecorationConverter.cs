using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View.Converters;

public class BoolToTextDecorationConverter : IValueConverter
{
    /// <summary>
    /// Конвертирует <see cref="bool" /> значение в <see cref="TextDecorations" />.
    /// </summary>
    /// <param name="value">Значение, которое необходимо преобразовать.</param>
    /// <param name="targetType">Тип, в который необходимо преобразовать.</param>
    /// <param name="parameter">Вспомогательный параметр.</param>
    /// <param name="culture">Текущая культура приложения.</param>
    /// <returns>Возвращает значение видимости элемента.</returns>
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return (bool)value ? TextDecorations.Strikethrough : null;
    }

    /// <summary>
    /// Конвертирует <see cref="TextDecorations" /> значение в <see cref="bool" />.
    /// </summary>
    /// <param name="value">Значение, которое необходимо преобразовать.</param>
    /// <param name="targetType">Тип, в который необходимо преобразовать.</param>
    /// <param name="parameter">Вспомогательный параметр.</param>
    /// <param name="culture">Текущая культура приложения.</param>
    /// <returns>Возвращает пустое значение.</returns>
    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return DependencyProperty.UnsetValue;
    }
}