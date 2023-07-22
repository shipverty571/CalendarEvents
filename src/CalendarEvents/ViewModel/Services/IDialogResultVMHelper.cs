namespace ViewModel.Services;

public interface IDialogResultVMHelper
{
    event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
}