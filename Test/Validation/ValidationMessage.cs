using Test.Model;

namespace Test.Validation;

/// <summary>
/// Результат валидации свойства <see cref="ProjectElementBase"/>.
/// </summary>
public class ValidationMessage
{
    /// <summary>
    /// Возвращает элемент, к которому относится результат валидации.
    /// </summary>
    public required ProjectElementBase Target { get; init; }

    /// <summary>
    /// Возвращает наименование валидируемого свойства объекта.
    /// </summary>
    public required string PropertyName { get; init; }

    /// <summary>
    /// Возвращает валидационное сообщение.
    /// </summary>
    public required string Message { get; init; }
}