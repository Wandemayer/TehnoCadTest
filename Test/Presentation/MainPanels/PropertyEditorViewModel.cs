using Test.Model;
using Test.Presentation.PropertyPanels;

namespace Test.Presentation.MainPanels;

/// <summary>
/// Модель представления панели свойств элемента.
/// </summary>
public class PropertyEditorViewModel : ViewModelBase
{
    private ProjectElementBase? _editorElement;
    private ViewModelBase? _elementPropsViewModel;

    /// <summary>
    /// Возвращает или залает элемент, свойства которого будут рассмотрены.
    /// </summary>
    public ProjectElementBase? EditorElement
    {
        get => _editorElement;
        set
        {
            if (SetField(ref _editorElement, value))
            {
                ElementPropsViewModel = value switch
                {
                    Building building => new BuildingPropsViewModel(building),
                    Parcel parcel => new ParcelPropsViewModel(parcel),
                    _ => ElementPropsViewModel
                };
            }
        }
    }

    /// <summary>
    /// Возвращает модель представления панели свойств <see cref="EditorElement"/>.
    /// </summary>
    public ViewModelBase? ElementPropsViewModel
    {
        get => _elementPropsViewModel;
        private set
        {
            var oldPropViewModel = _elementPropsViewModel;
            
            if (SetField(ref _elementPropsViewModel, value))
            {
                oldPropViewModel?.Cleanup();
            }
        }
    }
}