using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel.Services;

namespace ViewModel;

public class MessageVM : ObservableObject, IDialogResultVMHelper
{
    public MessageVM()
    {
        CloseCommand = new RelayCommand(Close);
        OKCommand = new RelayCommand(OK);
    }
    
    public string Text { get; set; }
    
    public RelayCommand CloseCommand { get; }
    
    public RelayCommand OKCommand { get; }
    
    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
    
    private void Close()
    {
        InvokeRequestCloseDialog(
            new RequestCloseDialogEventArgs(false));
    }

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