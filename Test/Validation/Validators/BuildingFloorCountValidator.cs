using System;
using System.Collections.Generic;
using Test.Model;

namespace Test.Validation.Validators;

/// <summary>
/// Выполняет проверку количества этажей в здании.
/// </summary>
public class BuildingFloorCountValidator : ProjectElementValidator<Building>
{
    /// <inheritdoc />
    public override string PropertyName { get; } = nameof(Building.FloorCount);

    /// <inheritdoc />
    protected override IReadOnlyCollection<ValidationMessage> Validate(Building projectElement)
    {
        return projectElement.FloorCount switch
        {
            0 => new[]
            {
                new ValidationMessage
                {
                    Target = projectElement,
                    PropertyName = PropertyName,
                    Message = "Укажите количество этажей в здании"
                }
            },
            < 0 => new[]
            {
                new ValidationMessage
                {
                    Target = projectElement,
                    PropertyName = PropertyName,
                    Message = "Количество этажей в здании не может быть отрицательным"
                }
            },
            _ => ArraySegment<ValidationMessage>.Empty
        };
    }
}