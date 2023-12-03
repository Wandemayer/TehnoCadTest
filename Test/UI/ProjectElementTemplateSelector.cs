using System.Windows;
using System.Windows.Controls;
using Test.Model;

namespace Test.UI;

/// <summary>
/// Селектор шаблонов для элементов проекта.
/// </summary>
public class ProjectElementTemplateSelector : DataTemplateSelector
{
    /// <summary>
    /// Возвращает или задает шаблон для <see cref="Building"/>.
    /// </summary>
    public DataTemplate BuildingTemplate { get; set; } = null!;

    /// <summary>
    /// Возвращает или задает шаблон для <see cref="Parcel"/>.
    /// </summary>
    public DataTemplate ParcelTemplate { get; set; } = null!;

    /// <inheritdoc />
    public override DataTemplate SelectTemplate(object? item, DependencyObject container)
    {
        return item switch
        {
            Building => BuildingTemplate,
            Parcel => ParcelTemplate,
            _ => base.SelectTemplate(item, container)
        };
    }
}