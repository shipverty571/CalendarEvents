using System;
using System.Windows;
using View.Services;
using ViewModel.Services;

namespace View;

public partial class DialogWindow : Window
{
    private bool _isClosed = false;
    
    public DialogWindow()
    {
        InitializeComponent();
        DialogPresenter.DataContextChanged += DialogPresenterDataContextChanged;
        Closed += DialogWindowClosed;
    }

    public void DialogWindowClosed(object sender, EventArgs e)
    {
        _isClosed = true;
    }

    private void DialogPresenterDataContextChanged(object sender,
        DependencyPropertyChangedEventArgs e)
    {
        var d = e.NewValue as IDialogResultVMHelper;

        if (d == null)
            return;

        d.RequestCloseDialog +=
            new EventHandler<RequestCloseDialogEventArgs>(DialogResultTrueEvent);
    }

    private void DialogResultTrueEvent(object sender, RequestCloseDialogEventArgs e)
    {
        if (_isClosed) return;

        this.DialogResult = e.DialogResult;
    }
}