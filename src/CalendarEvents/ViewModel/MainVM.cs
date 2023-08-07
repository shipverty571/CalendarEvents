using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel.Services;

namespace ViewModel;

/// <summary>
/// ViewModel для окна MainWindow.
/// </summary>
public class MainVM : ObservableObject
{
    /// <summary>
    /// Путь до сериализации.
    /// </summary>
    private readonly string _path =
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        + @"/CalendarEvents/Tasks.json";

    /// <summary>
    /// Хранилище задач.
    /// </summary>
    private readonly EventRepository _repository;

    /// <summary>
    /// Создает экземпляр класса <see cref="MainVM" />.
    /// </summary>
    /// <param name="navigationService">Сервис навигации пользовательских элементов управления.</param>
    public MainVM(INavigationService navigationService, EventRepository repository)
    {
        _repository = repository;
        repository.Events = Serializer.Deserialize(_path);
        NavigationService = navigationService;
        NavigationService.NavigateTo<CalendarVM>();
    }

    /// <summary>
    /// Возвращает и задает сервис навигации пользовательских элементов управления.
    /// </summary>
    public INavigationService NavigationService { get; set; }

    public void OnWindowClosing(object sender, CancelEventArgs e)
    {
        Serializer.Serialize(_repository.Events, _path);
    }
}