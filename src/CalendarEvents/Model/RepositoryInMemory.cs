using System.Collections.ObjectModel;

namespace Model;

/// <summary>
/// Шаблонный класс хранилища.
/// </summary>
/// <typeparam name="T">Класс хранилища.</typeparam>
public class RepositoryInMemory<T>
{
    /// <summary>
    /// Коллекция.
    /// </summary>
    private readonly ObservableCollection<T> _collection;

    /// <summary>
    /// Создает экземпляр класса <see cref="RepositoryInMemory{T}" />.
    /// </summary>
    public RepositoryInMemory()
    {
        _collection = new ObservableCollection<T>();
    }

    /// <summary>
    /// Возвращает коллекцию.
    /// </summary>
    /// <returns>Возвращает коллекцию.</returns>
    public ObservableCollection<T> GetAll()
    {
        return _collection;
    }
}