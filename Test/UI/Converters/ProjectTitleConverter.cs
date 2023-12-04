using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Test.UI.Converters;

/// <summary>
/// 
/// </summary>
public class ProjectTitleConverter : MarkupExtension, IValueConverter
{
    /// <inheritdoc />
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    /// <inheritdoc />
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string projectElementTitle) return value;

        return string.IsNullOrWhiteSpace(projectElementTitle) 
            ? parameter 
            : projectElementTitle;
    }

    /// <inheritdoc />
    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}