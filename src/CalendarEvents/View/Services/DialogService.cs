using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.Services;

namespace View.Services;

/// <summary>
/// Диалоговый сервис.
/// </summary>
public class DialogService : IDialogService
{
    /// <summary>
    /// Базовое значение высоты диалогового окна.
    /// </summary>
    private const int DefaultHeightWindow = 450;

    /// <summary>
    /// Базовое значение ширины диалогового окна.
    /// </summary>
    private const int DefaultWidthWindow = 800;

    /// <summary>
    /// Окно.
    /// </summary>
    private Window _dialog;

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

    public bool ShowMessage(string caption, string text)
    {
        var messageBox = MessageBox.Show(text, caption, MessageBoxButton.OKCancel);
        if (messageBox == MessageBoxResult.OK) return true;

        return false;
    }
}