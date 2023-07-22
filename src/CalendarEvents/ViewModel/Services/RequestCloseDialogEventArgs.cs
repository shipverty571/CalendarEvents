using System;

namespace ViewModel.Services;

public class RequestCloseDialogEventArgs : EventArgs
{
    public bool DialogResult { get; set; }
    
    public RequestCloseDialogEventArgs(bool dialogresult)
    {
        this.DialogResult = dialogresult;
    }
}