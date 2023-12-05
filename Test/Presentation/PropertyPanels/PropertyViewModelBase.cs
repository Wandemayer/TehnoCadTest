namespace Test.Presentation.PropertyPanels;

/// <summary>
/// Базовая абстрактная модель представления свойства.
/// </summary>
public abstract class PropertyViewModelBase : ViewModelBase
{
    private bool _isFocused;

    protected PropertyViewModelBase(string propertyName)
    {
        PropertyName = propertyName;
    }

    /// <summary>
    /// Возвращает наименование свойства.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Возвращает или задает значение, определяющее, установлен ли на свойство фокус.
    /// </summary>
    public bool IsFocused
    {
        get => _isFocused;
        set => SetField(ref _isFocused, value);
    }
}