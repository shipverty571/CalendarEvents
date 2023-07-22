using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.Services;

namespace View.Services;

public class DialogService : ObservableObject, IDialogService
{
    private const int DefaultHeightWindow = 450;

    private const int DefaultWidthWindow = 800;

    private readonly Func<Type, ObservableObject> _viewModelFactory;

    private Window _dialog;
    
    public DialogService(Func<Type, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public int Height { get; set; } = DefaultHeightWindow;

    public int Width { get; set; } = DefaultWidthWindow;
    
    public bool? ShowDialog(ObservableObject viewModel)
    {
        _dialog = new DialogWindow();
        _dialog.Height = Height;
        _dialog.Width = Width;
        _dialog.DataContext = viewModel;
        _dialog.Owner = Application.Current.MainWindow;
        _dialog.ShowInTaskbar = false;
        return _dialog.ShowDialog();
    }

    public void Close()
    {
        _dialog.Close();
    }
}