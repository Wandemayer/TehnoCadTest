using Test.Common;

namespace Test.Model;

/// <summary>
/// Базовый абстрактный элемент проекта.
/// </summary>
public abstract class ProjectElementBase : ObservedElement
{
    private string _title = string.Empty;

    /// <summary>
    /// Возвращает или задает наименование элемента.
    /// </summary>
    public string Title
    {
        get => _title;
        set => SetField(ref _title, value);
    }
}