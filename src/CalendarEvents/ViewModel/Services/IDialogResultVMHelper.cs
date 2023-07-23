namespace ViewModel.Services;

/// <summary>
/// Хранит событие запроса закрытия окна.
/// </summary>
public interface IDialogResultVMHelper
{
    /// <summary>
    /// Событие запроса закрытия окна.
    /// </summary>
    event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
}