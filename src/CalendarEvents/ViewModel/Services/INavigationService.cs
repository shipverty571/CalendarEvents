using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

public interface INavigationService
{
    ObservableObject CurrentView { get; }

    void NavigateTo<T>() where T : ObservableObject;
}