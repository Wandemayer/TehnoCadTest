using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Test.Presentation.Command;
using Test.Validation;

namespace Test.Presentation.MainPanels;

/// <summary>
/// Модель представления панели ошибок.
/// </summary>
public class ValidationPanelViewModel : ViewModelBase
{
    private readonly ValidationService _validationService;
    private ValidationMessage? _selectedMessage;
    private ICommand? _selectRowCommand;

    public ValidationPanelViewModel(ValidationService validationService)
    {
        _validationService = validationService ?? throw new ArgumentNullException(nameof(validationService));
    }

    /// <summary>
    /// Возвращает выделенное на панели сообщение об ошибке.
    /// </summary>
    public ValidationMessage? SelectedMessage
    {
        get => _selectedMessage;
        private set => SetField(ref _selectedMessage, value);
    }

    /// <summary>
    /// Возвращает коллекцию ошибок.
    /// </summary>
    public ReadOnlyObservableCollection<ValidationMessage> Errors => _validationService.Errors;

    /// <summary>
    /// Возвращает команду выделения ошибки.
    /// </summary>
    public ICommand SelectRowCommand => _selectRowCommand ??= new RelayCommand<ValidationMessage>(SelectRow);

    private void SelectRow(ValidationMessage message)
    {
        SelectedMessage = message;
    }
}