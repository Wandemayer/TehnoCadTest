namespace Test.Model;

/// <summary>
/// Модель здания.
/// </summary>
public class Building : ProjectElementBase
{
    private int _floorCount;
    private string _address = string.Empty;
    private bool _isLiving;

    /// <summary>
    /// Возвращает или задает количество этажей в здании.
    /// </summary>
    public int FloorCount
    {
        get => _floorCount;
        set => SetField(ref _floorCount, value);
    }

    /// <summary>
    /// Возвращает или задает адрес здания.
    /// </summary>
    public string Address
    {
        get => _address;
        set => SetField(ref _address, value);
    }

    /// <summary>
    /// Возвращает или задает значение,
    /// определяющее является ли здание живым.
    /// </summary>
    public bool IsLiving
    {
        get => _isLiving;
        set => SetField(ref _isLiving, value);
    }
}