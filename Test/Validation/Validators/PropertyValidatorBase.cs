using System.Collections.Generic;
using Test.Model;

namespace Test.Validation.Validators;

/// <summary>
/// Базовый абстрактный валидатор свойства <see cref="ProjectElementBase"/>.
/// </summary>
public abstract class PropertyValidatorBase
{
    /// <summary>
    /// Возвращает наименование валидируемого свойства.
    /// </summary>
    public abstract string PropertyName { get; }
    
    /// <summary>
    /// Определяет необходимость валидации для передаваемого объекта.
    /// </summary>
    public abstract bool CanValidate(ProjectElementBase projectElement);

    /// <summary>
    /// Выполняет проверку передаваемого объекта.
    /// </summary>
    /// <param name="projectElement">Валидируемый объект.</param>
    /// <returns>Коллекция результатов валидации.</returns>
    public abstract IReadOnlyCollection<ValidationMessage> Validate(ProjectElementBase projectElement);
}