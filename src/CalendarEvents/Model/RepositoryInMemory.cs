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
    /// Создает экземпляр класса <see cref="RepositoryInMemory{T}"/>.
    /// </summary>
    public RepositoryInMemory()
    {
        _collection = new ObservableCollection<T>();
    }

    /// <summary>
    /// Создает экземпляр класса <see cref="RepositoryInMemory{T}"/>.
    /// </summary>
    /// <param name="collection">Коллекция.</param>
    public RepositoryInMemory(ObservableCollection<T> collection)
    {
        _collection = collection;
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