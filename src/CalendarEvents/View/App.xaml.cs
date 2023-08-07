using System;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using Model;
using View.Services;
using ViewModel;
using ViewModel.Services;

namespace View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<MainWindow>(provider => new MainWindow
        {
            DataContext = _serviceProvider.GetRequiredService<MainVM>()
        });
        services.AddSingleton<MainVM>();
        services.AddTransient<DayInfoVM>();
        services.AddSingleton<CalendarVM>();
        services.AddTransient<EventsManagementVM>();
        services.AddTransient<MessageVM>();
        services.AddSingleton<IDialogService, DialogService>();
        services.AddSingleton<EventRepository>();
        services.AddSingleton<Func<Type, ObservableObject>>(serviceProvider => viewModelType =>
            (ObservableObject)serviceProvider.GetRequiredService(viewModelType));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Closing += ((MainVM)mainWindow.DataContext).OnWindowClosing;
        mainWindow.Show();
        base.OnStartup(e);
    }
}