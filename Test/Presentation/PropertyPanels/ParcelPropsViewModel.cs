using Test.Model;

namespace Test.Presentation.PropertyPanels;

/// <summary>
/// Модель представления свойств участка.
/// </summary>
public class ParcelPropsViewModel : ElementPropsViewModel<Parcel>
{
    /// <inheritdoc />
    public ParcelPropsViewModel(Parcel element) : base(element)
    {
        Number = RegisterProperty(new PropertyViewModel<Parcel, string>(element, nameof(Parcel.Number)));
        Location = RegisterProperty(new PropertyViewModel<Parcel, string>(element, nameof(Parcel.Location)));
    }

    /// <summary>
    /// Возвращает или задает номер участка.
    /// </summary>
    public PropertyViewModel<Parcel, string> Number { get; }

    /// <summary>
    /// Возвращает или задает описание местоположения участка.
    /// </summary>
    public PropertyViewModel<Parcel, string> Location { get; }
}