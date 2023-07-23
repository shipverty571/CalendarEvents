using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

/// <summary>
/// Интерфейс для сервиса диалоговых окон
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Возвращает и задает высоту диалогового окна.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Возвращает и задает ширину диалогового окна.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Вызывает диалоговое окно
    /// </summary>
    /// <param name="viewModel">ViewModel.</param>
    /// <returns>Возвращает результат вызова диалогового окна.</returns>
    public bool? ShowDialog(ObservableObject viewModel);

    /// <summary>
    /// Вызывает диалоговое окно с сообщением.
    /// </summary>
    /// <param name="caption">Заголовок окна.</param>
    /// <param name="text">Текст окна.</param>
    /// <returns>Возвращает результат вызова диалогового окна.</returns>
    public bool ShowMessage(string caption, string text);
}