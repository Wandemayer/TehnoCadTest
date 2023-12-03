using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Test.Common;

/// <summary>
/// Абстрактный класс определяющий объект, оповещающий о своем изменении.
/// </summary>
public abstract class ObservedElement : INotifyPropertyChanged
{
    /// <inheritdoc />
    public event PropertyChangedEventHandler? PropertyChanged;
    
    /// <summary>
    /// Сравнивает текущее и новое значения свойства.
    /// Если значения не равны, то устанавливает новое значение и
    /// генерирует событие <see cref="PropertyChanged"/>.
    /// </summary>
    /// <typeparam name="T">Тип изменяемого свойства.</typeparam>
    /// <param name="field">Поле изменяемого свойства.</param>
    /// <param name="value">Новое устанавливаемое значение.</param>
    /// <param name="propertyName">Имя изменяемого свойства.</param>
    /// <returns><see langword="true"/>, если свойство было изменено; иначе <see langword="false"/>.</returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }
        
        field = value;
        
        OnPropertyChanged(propertyName);
        
        return true;
    }
    
    /// <summary>
    /// Генерирует <see cref="PropertyChanged"/>.
    /// </summary>
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}