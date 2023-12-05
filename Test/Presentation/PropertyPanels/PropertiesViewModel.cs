using System.Collections.Generic;

namespace Test.Presentation.PropertyPanels;

/// <summary>
/// Базовая абстрактная модель представления панели свойств.
/// </summary>
public abstract class PropertiesViewModel : ViewModelBase
{
    private readonly List<PropertyViewModelBase> _properties = new();

    /// <summary>
    /// Выполняет регистрацию передаваемой модели представления свойства.
    /// </summary>
    protected TPropertyViewModel RegisterProperty<TPropertyViewModel>(TPropertyViewModel property) 
        where TPropertyViewModel : PropertyViewModelBase
    {
        _properties.Add(property);

        return property;
    }

    /// <summary>
    /// Устанавливает фокус на свойство.
    /// </summary>
    /// <param name="propertyName">Наименование фокусируемого свойства.</param>
    public void SetFocus(string propertyName)
    {
        foreach (var property in _properties)
        {
            property.IsFocused = property.PropertyName == propertyName;
        }
    }

    /// <inheritdoc />
    public override void Cleanup()
    {
        foreach (var property in _properties)
        {
            property.Cleanup();
        }

        base.Cleanup();
    }
}