using Test.Common;

namespace Test.Presentation;

/// <summary>
/// Базовый абстрактный класс модели представления.
/// </summary>
public abstract class ViewModelBase : ObservedElement
{
    /// <summary>
    /// Выполняет отчистку ресурсов связанных с моделью представления.
    /// </summary>
    public virtual void Cleanup()
    {
        
    }
}