using System.ComponentModel;
using Test.Model;

namespace Test.Presentation.MainPanels;

/// <summary>
/// Модель представления главного окна.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var project = new Project();

        ProjectExplorerViewModel = new ProjectExplorerViewModel(project);
        PropertyEditorViewModel = new PropertyEditorViewModel();
        
        ProjectExplorerViewModel.PropertyChanged += ProjectExplorerViewModelOnPropertyChanged;
    }

    /// <summary>
    /// Возвращает модель представления обозревателя проекта.
    /// </summary>
    public ProjectExplorerViewModel ProjectExplorerViewModel { get; }

    /// <summary>
    /// Возвращает модель представления окна редактирования элементов.
    /// </summary>
    public PropertyEditorViewModel PropertyEditorViewModel { get; }
    
    private void ProjectExplorerViewModelOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ProjectExplorerViewModel.SelectedProjectElement))
        {
            PropertyEditorViewModel.EditorElement = ProjectExplorerViewModel.SelectedProjectElement;
        }
    }
}