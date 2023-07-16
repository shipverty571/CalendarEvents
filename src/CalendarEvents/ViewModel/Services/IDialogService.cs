using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

/// <summary>
/// Интерфейс для сервиса диалоговых окон
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Возвращает и задает высоту окна.
    /// </summary>
    public int Height { get; set; }
    
    /// <summary>
    /// Возвращает и задает ширину окна.
    /// </summary>
    public int Width { get; set; }
    
    /// <summary>
    /// Вызывает диалоговое окно с выбранным объектов ViewModel.
    /// </summary>
    /// <typeparam name="T">ViewModel.</typeparam>
    public void ShowDialog<T>() where T: ObservableObject;

    /// <summary>
    /// Закрывает диалоговое окно.
    /// </summary>
    public void Close();
}