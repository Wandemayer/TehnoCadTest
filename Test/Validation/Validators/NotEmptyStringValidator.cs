using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Test.Model;

namespace Test.Validation.Validators;

/// <summary>
/// Проверяет строковое свойство элементов проекта на наличие данных.
/// </summary>
/// <typeparam name="TElement">Тип проверяемого элемента.</typeparam>
public class NotEmptyStringValidator<TElement> : ProjectElementValidator<TElement>
    where TElement : ProjectElementBase
{
    private readonly Expression<Func<TElement, string>> _property;
    private readonly string _message;

    public NotEmptyStringValidator(Expression<Func<TElement, string>> property, string message)
    {
        _property = property ?? throw new ArgumentNullException(nameof(property));
        _message = message ?? throw new ArgumentNullException(nameof(message));

        var expression = (MemberExpression)property.Body;
        PropertyName = expression.Member.Name;
    }

    /// <inheritdoc />
    public override string PropertyName { get; }

    /// <inheritdoc />
    protected override IReadOnlyCollection<ValidationMessage> Validate(TElement projectElement)
    {
        string propertyValue = _property.Compile()(projectElement);

        if (string.IsNullOrWhiteSpace(propertyValue))
        {
            return new[]
            {
                new ValidationMessage
                {
                    Target = projectElement,
                    PropertyName = PropertyName,
                    Message = _message
                }
            };
        }

        return ArraySegment<ValidationMessage>.Empty;
    }
}