namespace Test.Model;

/// <summary>
/// Модель участка.
/// </summary>
public class Parcel : ProjectElementBase
{
    private string _number = string.Empty;
    private string _location = string.Empty;

    /// <summary>
    /// Возвращает или задает номер участка.
    /// </summary>
    public string Number
    {
        get => _number;
        set => SetField(ref _number, value);
    }

    /// <summary>
    /// Возвращает или задает описание местоположения участка.
    /// </summary>
    public string Location
    {
        get => _location;
        set => SetField(ref _location, value);
    }
}