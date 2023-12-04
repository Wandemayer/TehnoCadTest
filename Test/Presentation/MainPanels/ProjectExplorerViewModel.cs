using System;
using System.Windows.Input;
using Test.Model;
using Test.Presentation.Command;

namespace Test.Presentation.MainPanels;

/// <summary>
/// Модель представления обозревателя проекта.
/// </summary>
public class ProjectExplorerViewModel : ViewModelBase
{
    private ICommand? _addBuildingCommand;
    private ICommand? _addParcelCommand;
    private ProjectElementBase? _selectedProjectElement;

    [Obsolete(DesignMessages.DesignCtorMessage, true)]
    public ProjectExplorerViewModel()
    {
        Project = new Project();

        var building = Project.CreateElement<Building>();
        building.Title = "Здание 1";
        
        var parcel = Project.CreateElement<Parcel>();
        parcel.Title = "Участок 1";

        Project.CreateElement<Parcel>();
    }

    public ProjectExplorerViewModel(Project project)
    {
        Project = project ?? throw new ArgumentNullException(nameof(project));
    }

    /// <summary>
    /// Возвращает проект.
    /// </summary>
    public Project Project { get; }

    /// <summary>
    /// Возвращает выбранный в обозревателе элемент проекта.
    /// </summary>
    public ProjectElementBase? SelectedProjectElement
    {
        get => _selectedProjectElement;
        set => SetField(ref _selectedProjectElement, value);
    }

    /// <summary>
    /// Возвращает команду добавления здания.
    /// </summary>
    public ICommand AddBuildingCommand => _addBuildingCommand ??= new RelayCommand(AddBuilding);

    private void AddBuilding()
    {
        SelectedProjectElement = Project.CreateElement<Building>();
    }

    /// <summary>
    /// Возвращает команду добавления участка.
    /// </summary>
    public ICommand AddParcelCommand => _addParcelCommand ??= new RelayCommand(AddParcel);

    private void AddParcel()
    {
        SelectedProjectElement = Project.CreateElement<Parcel>();
    }
}