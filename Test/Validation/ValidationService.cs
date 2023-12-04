using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Test.Model;
using Test.Validation.Validators;

namespace Test.Validation;

/// <summary>
/// Предоставляет функционал валидирования объектов.
/// </summary>
public class ValidationService
{
    private readonly Dictionary<ProjectElementBase, Dictionary<string, List<ValidationMessage>>> _errorsByTargetProperty = new();
    private readonly ObservableCollection<ValidationMessage> _allItemsErrors = new();
    private readonly IReadOnlyCollection<PropertyValidatorBase> _validators;

    public ValidationService(Project project)
    {
        if (project is null) throw new ArgumentNullException(nameof(project));

        Errors = new ReadOnlyObservableCollection<ValidationMessage>(_allItemsErrors);
        _validators = new List<PropertyValidatorBase>
        {
            new NotEmptyStringValidator<ProjectElementBase>(p => p.Title, "Укажите наименование объекта"),
            new NotEmptyStringValidator<Building>(p => p.Address, "Укажите адрес здания"),
            new NotEmptyStringValidator<Parcel>(p => p.Location, "Опишите местоположение участка"),
            new NotEmptyStringValidator<Parcel>(p => p.Number, "Укажите номер участка"),
            new BuildingFloorCountValidator()
        };

        ((INotifyCollectionChanged)project.Elements).CollectionChanged += OnProjectElementsCollectionChanged;
    }

    /// <summary>
    /// Возвращает коллекцию ошибок объектов.
    /// </summary>
    public ReadOnlyObservableCollection<ValidationMessage> Errors { get; }

    private void OnProjectElementsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
            {
                if (e.NewItems is null) break;
                foreach (ProjectElementBase newItem in e.NewItems)
                {
                    newItem.PropertyChanged += OnProjectElementPropertyChanged;
                    _errorsByTargetProperty[newItem] = new Dictionary<string, List<ValidationMessage>>();
                    ValidateElement(newItem);
                }

                break;
            }
            case NotifyCollectionChangedAction.Remove:
            {
                if (e.OldItems is null) break;
                foreach (ProjectElementBase oldItem in e.OldItems)
                {
                    oldItem.PropertyChanged -= OnProjectElementPropertyChanged;
                    _errorsByTargetProperty[oldItem].Clear();
                    _errorsByTargetProperty.Remove(oldItem);
                }

                break;
            }
        }
    }

    private void OnProjectElementPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (sender is not ProjectElementBase projectElement) return;
        if (e.PropertyName is null) return;

        ClearExisingErrors();
        ValidateProperty();

        void ClearExisingErrors()
        {
            if (!_errorsByTargetProperty[projectElement].TryGetValue(e.PropertyName, out var exisingErrors)) return;

            foreach (var propertyError in exisingErrors)
            {
                _allItemsErrors.Remove(propertyError);
            }
        }

        void ValidateProperty()
        {
            foreach (var propertyValidator in _validators)
            {
                if (!propertyValidator.CanValidate(projectElement)) continue;
                if (propertyValidator.PropertyName != e.PropertyName) continue;

                ValidateElement(propertyValidator, projectElement);
            }
        }
    }

    private void ValidateElement(ProjectElementBase projectElement)
    {
        foreach (var propertyValidator in _validators)
        {
            if (!propertyValidator.CanValidate(projectElement)) continue;

            _errorsByTargetProperty[projectElement][propertyValidator.PropertyName] = new List<ValidationMessage>();

            ValidateElement(propertyValidator, projectElement);
        }
    }

    private void ValidateElement(PropertyValidatorBase propertyValidator, ProjectElementBase projectElement)
    {
        var propertyErrors = propertyValidator.Validate(projectElement);

        foreach (var propertyError in propertyErrors)
        {
            _errorsByTargetProperty[projectElement][propertyValidator.PropertyName].Add(propertyError);
            _allItemsErrors.Add(propertyError);
        }
    }
}