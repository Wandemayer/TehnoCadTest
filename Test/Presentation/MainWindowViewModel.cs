using Test.Model;

namespace Test.Presentation;

/// <summary>
/// Модель представления главного окна.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var project = new Project();
        
        ProjectExplorerViewModel = new ProjectExplorerViewModel(project);
    }

    /// <summary>
    /// Возвращает модель представления обозревателя проекта.
    /// </summary>
    public ProjectExplorerViewModel ProjectExplorerViewModel { get; }
}