using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ViewModel.Services;

public class NavigationService : ObservableObject, INavigationService
{
    private ObservableObject _currentView;

    private readonly Func<Type, ObservableObject> _viewModelFactory;

    public NavigationService(Func<Type, ObservableObject> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public ObservableObject CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }

    public void NavigateTo<TViewModel>() where TViewModel : ObservableObject
    {
        var viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
        CurrentView = viewModel;
    }
}