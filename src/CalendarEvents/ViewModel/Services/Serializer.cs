using System.Collections.ObjectModel;
using Model;
using Newtonsoft.Json;

namespace ViewModel.Services;

/// <summary>
/// Представляет реализацию по сериализации задач.
/// </summary>
public static class Serializer
{
    /// <summary>
    /// Проводит сериализацию данных.
    /// </summary>
    /// <param name="events">Коллекция задач..</param>
    /// <param name="path">Путь сериализации.</param>
    public static void Serialize(ObservableCollection<DayTask> events, string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        using (var writer = new StreamWriter(path))
        {
            var jsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented };
            writer.Write(JsonConvert.SerializeObject(events, jsonSettings));
        }
    }

    /// <summary>
    /// Проводит десериализацию данных.
    /// </summary>
    /// <param name="path">Путь десериализации.</param>
    /// <returns>Возвращает экземпляр коллекции <see cref="ObservableCollection<DayTask>" />.</returns>
    public static ObservableCollection<DayTask> Deserialize(string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));
        if (!File.Exists(path)) return new ObservableCollection<DayTask>();
        using (var reader = new StreamReader(path))
        {
            var events =
                JsonConvert.DeserializeObject<ObservableCollection<DayTask>>(
                    reader.ReadToEnd()) ??
                new ObservableCollection<DayTask>();
            return events;
        }
    }
}