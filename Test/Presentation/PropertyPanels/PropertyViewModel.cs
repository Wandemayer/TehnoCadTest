using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Test.Model;

namespace Test.Presentation.PropertyPanels;

public class PropertyViewModel<TElement, TProperty> : PropertyViewModelBase
    where TElement : ProjectElementBase
{
    private readonly TElement _source;
    private readonly Func<TElement, TProperty> _getValue;
    private readonly Action<TElement, TProperty> _setValue;

    public PropertyViewModel(TElement source, string propertyName) : base(propertyName)
    {
        _source = source;

        _getValue = CreatePropGetter(propertyName);
        _setValue = CreatePropSetter(propertyName);

        _source.PropertyChanged += SourceOnPropertyChanged;
    }

    /// <summary>
    /// Возвращает или задает значение свойства.
    /// </summary>
    public TProperty Value
    {
        get => _getValue(_source);
        set => _setValue(_source, value);
    }

    /// <summary>
    /// Выполняет отчистку используемых ресурсов.
    /// </summary>
    public override void Cleanup()
    {
        _source.PropertyChanged -= SourceOnPropertyChanged;
    }

    private void SourceOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == PropertyName)
        {
            OnPropertyChanged(nameof(Value));
        }
    }

    private static Func<TElement, TProperty> CreatePropGetter(string propertyName)
    {
        var paramExpression = Expression.Parameter(typeof(TElement), "value");

        Expression propertyGetterExpression = Expression.Property(paramExpression, propertyName);

        return Expression.Lambda<Func<TElement, TProperty>>(propertyGetterExpression, paramExpression).Compile();
    }

    private static Action<TElement, TProperty> CreatePropSetter(string propertyName)
    {
        var sourceParam = Expression.Parameter(typeof(TElement));
        var valueParam = Expression.Parameter(typeof(TProperty), propertyName);
        var propertyGetterExpression = Expression.Property(sourceParam, propertyName);

        var body = Expression.Assign(propertyGetterExpression, valueParam);

        return Expression.Lambda<Action<TElement, TProperty>>(body, sourceParam, valueParam)
            .Compile();
    }
}