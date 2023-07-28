using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace View.Converters;

/// <summary>
/// Представляет реализацию для конвертирования <see cref="Color" /> значений.
/// </summary>
public class ColorToBrushConverter : IValueConverter
{
    /// <summary>
    /// Конвертирует <see cref="string" /> значение в <see cref="object" />.
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
        
        var color = System.Drawing.ColorTranslator.FromHtml((string) value);
        var mediaColor = Color.FromArgb(color.A, color.R, color.G, color.B);
        return new SolidColorBrush(mediaColor);
    }

    /// <summary>
    /// Конвертирует <see cref="object" /> значение в <see cref="string" />.
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