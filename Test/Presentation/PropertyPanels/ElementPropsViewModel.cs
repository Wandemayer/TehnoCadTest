using System;
using Test.Model;

namespace Test.Presentation.PropertyPanels;

/// <summary>
/// Базовая абстрактная модель представления свойств элементов проекта.
/// </summary>
/// <typeparam name="TElement">Тип элемента проекта.</typeparam>
public abstract class ElementPropsViewModel<TElement> : PropertiesViewModel
    where TElement : ProjectElementBase
{
    protected ElementPropsViewModel(TElement element)
    {
        Element = element ?? throw new ArgumentNullException(nameof(element));

        Title = RegisterProperty(new PropertyViewModel<TElement, string>(element, nameof(Title)));
    }

    /// <summary>
    /// Возвращает экземпляр элемента.
    /// </summary>
    protected TElement Element { get; }

    /// <summary>
    /// Возвращает или задает наименование объекта.
    /// </summary>
    public PropertyViewModel<TElement, string> Title { get; }

    /// <summary>
    /// Возвращает Id элемента.
    /// </summary>
    public Guid Id => Element.Id;
}