using System;
using System.ComponentModel;
using Test.Model;

namespace Test.Presentation;

/// <summary>
/// Базовая абстрактная модель представления свойств элементов проекта.
/// </summary>
/// <typeparam name="TElement">Тип элемента проекта.</typeparam>
public abstract class ElementPropsViewModel<TElement> : ViewModelBase 
    where TElement : ProjectElementBase
{
    protected ElementPropsViewModel(TElement element)
    {
        Element = element ?? throw new ArgumentNullException(nameof(element));
        
        Element.PropertyChanged += ElementOnPropertyChanged;
    }

    /// <summary>
    /// Возвращает экземпляр элемента.
    /// </summary>
    protected TElement Element { get; }

    /// <summary>
    /// Возвращает или задает наименование объекта.
    /// </summary>
    public string Title
    {
        get => Element.Title;
        set => Element.Title = value;
    }

    /// <inheritdoc />
    public override void Cleanup()
    {
        Element.PropertyChanged -= ElementOnPropertyChanged;
        base.Cleanup();
    }
    
    protected virtual void ElementOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ProjectElementBase.Title))
        {
            OnPropertyChanged(nameof(Title));
        }
    }
}