namespace ViewModel.Services;

/// <summary>
/// Класс аргументов события закрытия окна.
/// </summary>
public class RequestCloseDialogEventArgs : EventArgs
{
    /// <summary>
    /// Создает экземпляр класса <see cref="RequestCloseDialogEventArgs" />.
    /// </summary>
    /// <param name="dialogresult">Результат диалога.</param>
    public RequestCloseDialogEventArgs(bool dialogresult)
    {
        DialogResult = dialogresult;
    }

    /// <summary>
    /// Возвращает и задает результат диалога.
    /// </summary>
    public bool DialogResult { get; private set; }
}