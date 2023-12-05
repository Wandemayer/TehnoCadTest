using System.ComponentModel;
using Test.Model;
using Test.Validation;

namespace Test.Presentation.MainPanels;

/// <summary>
/// Модель представления главного окна.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var project = new Project();
        var validationService = new ValidationService(project);
        
        ProjectExplorerViewModel = new ProjectExplorerViewModel(project);
        PropertyEditorViewModel = new PropertyEditorViewModel();
        ValidationPanelViewModel = new ValidationPanelViewModel(validationService);
        
        ProjectExplorerViewModel.PropertyChanged += ProjectExplorerViewModelOnPropertyChanged;
        ValidationPanelViewModel.PropertyChanged += ValidationPanelViewModelOnPropertyChanged;
    }

    /// <summary>
    /// Возвращает модель представления обозревателя проекта.
    /// </summary>
    public ProjectExplorerViewModel ProjectExplorerViewModel { get; }

    /// <summary>
    /// Возвращает модель представления окна редактирования элементов.
    /// </summary>
    public PropertyEditorViewModel PropertyEditorViewModel { get; }
    
    /// <summary>
    /// Возвращает модель представления окна ошибок.
    /// </summary>
    public ValidationPanelViewModel ValidationPanelViewModel { get; }
    
    private void ProjectExplorerViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ProjectExplorerViewModel.SelectedProjectElement))
        {
            PropertyEditorViewModel.EditorElement = ProjectExplorerViewModel.SelectedProjectElement;
        }
    }

    private void ValidationPanelViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(ValidationPanelViewModel.SelectedMessage)) return;
        if (ValidationPanelViewModel.SelectedMessage is null) return;
        
        ProjectExplorerViewModel.SelectedProjectElement = ValidationPanelViewModel.SelectedMessage.Target;
        PropertyEditorViewModel.SetFocusOnProperty(ValidationPanelViewModel.SelectedMessage.PropertyName);
    }
}