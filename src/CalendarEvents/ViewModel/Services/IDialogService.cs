using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

public interface IDialogService
{
    void ShowDialog<T>() where T: ObservableObject;

    void Close();
}