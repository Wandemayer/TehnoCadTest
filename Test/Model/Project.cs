using System.Collections.ObjectModel;

namespace Test.Model;

/// <summary>
/// Класс проекта.
/// </summary>
public class Project
{
    private readonly ObservableCollection<ProjectElementBase> _elements = new();

    public Project()
    {
        Elements = new ReadOnlyObservableCollection<ProjectElementBase>(_elements);
    }

    /// <summary>
    /// Возвращает коллекцию элементов.
    /// </summary>
    public ReadOnlyObservableCollection<ProjectElementBase> Elements { get; }

    /// <summary>
    /// Создает новый элемент проекта.
    /// </summary>
    /// <typeparam name="TElement">Тип создаваемого элемента.</typeparam>
    /// <returns>Экземпляр созданного объекта.</returns>
    public TElement CreateElement<TElement>()
        where TElement : ProjectElementBase, new()
    {
        var element = new TElement();

        _elements.Add(element);

        return element;
    }
}