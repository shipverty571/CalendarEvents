using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для MessageControl.
/// </summary>
public class MessageVM : ObservableObject, IDialogResultVMHelper
{
    /// <summary>
    /// Создает экземпляр класса <see cref="MessageVM"/>.
    /// </summary>
    public MessageVM()
    {
        CloseCommand = new RelayCommand(Close);
        OKCommand = new RelayCommand(OK);
    }

    /// <summary>
    /// Возвращает и задает текст сообщения.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Возвращает команду отмены.
    /// </summary>
    public RelayCommand CloseCommand { get; }

    /// <summary>
    /// Возвращает команду согласия.
    /// </summary>
    public RelayCommand OKCommand { get; }

    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;

    /// <summary>
    /// Закрывает окно без изменений.
    /// </summary>
    private void Close()
    {
        InvokeRequestCloseDialog(
            new RequestCloseDialogEventArgs(false));
    }

    /// <summary>
    /// Закрывает окно с принятием изменений.
    /// </summary>
    private void OK()
    {
        InvokeRequestCloseDialog(
            new RequestCloseDialogEventArgs(true));
    }

    private void InvokeRequestCloseDialog(RequestCloseDialogEventArgs e)
    {
        RequestCloseDialog.Invoke(this, e);
    }
}