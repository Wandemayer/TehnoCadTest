using System.ComponentModel;
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
    }
    
    /// <summary>
    /// Возвращает или задает номер участка.
    /// </summary>
    public string Number
    {
        get => Element.Number;
        set => Element.Number = value;
    }

    /// <summary>
    /// Возвращает или задает описание местоположения участка.
    /// </summary>
    public string Location
    {
        get => Element.Location;
        set => Element.Location = value;
    }

    /// <inheritdoc />
    protected override void ElementOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(Parcel.Number):
            {
                OnPropertyChanged(nameof(Number));
                break;
            }
            case nameof(Parcel.Location):
            {
                OnPropertyChanged(nameof(Location));
                break;
            }
        }
        
        base.ElementOnPropertyChanged(sender, e);
    }
}