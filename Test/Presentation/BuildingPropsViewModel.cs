using System.ComponentModel;
using Test.Model;

namespace Test.Presentation;

/// <summary>
/// Модель представления свойств здания. 
/// </summary>
public class BuildingPropsViewModel : ElementPropsViewModel<Building>
{
    /// <inheritdoc />
    public BuildingPropsViewModel(Building element) : base(element)
    {
    }
    
    /// <summary>
    /// Возвращает или задает количество этажей в здании.
    /// </summary>
    public int FloorCount
    {
        get => Element.FloorCount;
        set => Element.FloorCount = value;
    }

    /// <summary>
    /// Возвращает или задает адрес здания.
    /// </summary>
    public string Address
    {
        get => Element.Address;
        set => Element.Address = value;
    }

    /// <summary>
    /// Возвращает или задает значение,
    /// определяющее является ли здание живым.
    /// </summary>
    public bool IsLiving
    {
        get => Element.IsLiving;
        set => Element.IsLiving = value;
    }

    /// <inheritdoc />
    protected override void ElementOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Building.FloorCount):
            {
                OnPropertyChanged(nameof(FloorCount));
                break;
            }
            case nameof(Building.Address):
            {
                OnPropertyChanged(nameof(Address));
                break;
            }
            case nameof(Building.IsLiving):
            {
                OnPropertyChanged(nameof(IsLiving));
                break;
            }
        }
        
        base.ElementOnPropertyChanged(sender, e);
    }
}