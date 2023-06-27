using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using View.Enums;

namespace View.Converters;

/// <summary>
/// Представляет реализацию для конвертирования <see cref="int" /> значений.
/// </summary>
public class IntToMonthConverter : IValueConverter
{
    /// <summary>
    /// Конвертирует <see cref="int" /> значение в <see cref="Month" />.
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
        return ((Month)value).ToString();
    }

    /// <summary>
    /// Конвертирует <see cref="object" /> значение в <see cref="int" />.
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