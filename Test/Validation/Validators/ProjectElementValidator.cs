using System.Collections.Generic;
using Test.Model;

namespace Test.Validation.Validators;

/// <summary>
/// Типизированный абстрактный класс валидатора элементов проекта. 
/// </summary>
/// <typeparam name="TElement">Тип валидируемого элемента</typeparam>
public abstract class ProjectElementValidator<TElement> : PropertyValidatorBase
    where TElement : ProjectElementBase
{
    /// <inheritdoc />
    public override bool CanValidate(ProjectElementBase projectElement)
    {
        return projectElement is TElement;
    }

    /// <inheritdoc />
    public override IReadOnlyCollection<ValidationMessage> Validate(ProjectElementBase projectElement)
    {
        return Validate((TElement)projectElement);
    }

    /// <inheritdoc cref="Validate"/>
    protected abstract IReadOnlyCollection<ValidationMessage> Validate(TElement projectElement);
}