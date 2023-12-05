using Test.Model;

namespace Test.Presentation.PropertyPanels;

/// <summary>
/// Модель представления свойств здания. 
/// </summary>
public class BuildingPropsViewModel : ElementPropsViewModel<Building>
{
    /// <inheritdoc />
    public BuildingPropsViewModel(Building element) : base(element)
    {
        FloorCount = RegisterProperty(new PropertyViewModel<Building, int>(element, nameof(Building.FloorCount)));
        Address = RegisterProperty(new PropertyViewModel<Building, string>(element, nameof(Building.Address)));
        IsLiving = RegisterProperty(new PropertyViewModel<Building, bool>(element, nameof(Building.IsLiving)));
    }
    
    /// <summary>
    /// Возвращает или задает количество этажей в здании.
    /// </summary>
    public PropertyViewModel<Building, int> FloorCount { get; }
    
    /// <summary>
    /// Возвращает или задает адрес здания.
    /// </summary>
    public PropertyViewModel<Building, string> Address { get; }
    
    /// <summary>
    /// Возвращает или задает значение,
    /// определяющее является ли здание живым.
    /// </summary>
    public PropertyViewModel<Building, bool> IsLiving { get; }
}