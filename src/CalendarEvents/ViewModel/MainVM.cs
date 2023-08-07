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
    public MainVM(Func<Type, ObservableObject> viewModelFactory, EventRepository repository)
    {
        _repository = repository;
        repository.Events = Serializer.Deserialize(_path);
        CalendarVM = (CalendarVM)viewModelFactory.Invoke(typeof(CalendarVM));
    }

    public CalendarVM CalendarVM { get; set; }

    public void OnWindowClosing(object sender, CancelEventArgs e)
    {
        Serializer.Serialize(_repository.Events, _path);
    }
}