using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

public interface IDialogService
{
    int Height { get; set; }
    
    int Width { get; set; }
    
    void ShowDialog<T>() where T: ObservableObject;

    void Close();
}