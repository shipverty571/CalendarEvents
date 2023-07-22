using System;
using ViewModel.Services;

namespace View.Services;

public class DialogResultVMHelper : IDialogResultVMHelper
{
    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
}