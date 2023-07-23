using System;
using ViewModel.Services;

namespace View.Services;

/// <summary>
/// Хранит событие запроса закрытия окна.
/// </summary>
public class DialogResultVMHelper : IDialogResultVMHelper
{
    /// <summary>
    /// Событие запроса закрытия окна.
    /// </summary>
    public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;
}