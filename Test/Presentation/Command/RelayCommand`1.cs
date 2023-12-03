using System;
using System.Reflection;
using System.Windows.Input;

namespace Test.Presentation.Command;

#nullable disable

/// <summary>
/// Определяет команду для выполнения с возможностью передачи параметра заданного типа.
/// </summary>
/// <typeparam name="T">Тип параметра команды.</typeparam>
public class RelayCommand<T> : ICommand
{
    private readonly Action<T> _execute;
    private readonly Predicate<T> _canExecute;
    private readonly bool _paramIsValue;

    public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
        _paramIsValue = typeof(T).GetTypeInfo().IsValueType;
    }

    /// <inheritdoc />
    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    /// <inheritdoc />
    public void Execute(object parameter)
    {
        if (CanExecute(parameter))
        {
            _execute((T)parameter);
        }
    }

    /// <inheritdoc />
    public bool CanExecute(object parameter)
    {
        if (_canExecute is null)
        {
            return true;
        }

        return parameter switch
        {
            null when _paramIsValue => _canExecute.Invoke(default),
            null or T => _canExecute.Invoke((T)parameter),
            _ => false
        };
    }
}