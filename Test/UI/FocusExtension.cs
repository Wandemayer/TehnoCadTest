using System.Windows;
using System.Windows.Input;

namespace Test.UI;

public static class FocusExtension
{
    public static readonly DependencyProperty IsFocusedProperty =
        DependencyProperty.RegisterAttached(
            "IsFocused", typeof(bool), typeof(FocusExtension),
            new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

    public static bool GetIsFocused(DependencyObject obj)
    {
        return (bool)obj.GetValue(IsFocusedProperty);
    }

    public static void SetIsFocused(DependencyObject obj, bool value)
    {
        obj.SetValue(IsFocusedProperty, value);
    }

    private static void OnIsFocusedPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var uie = (UIElement)d;
        if (e.NewValue is true)
        {
            FocusManager.SetFocusedElement(FocusManager.GetFocusScope(uie), null);
            uie.Focus();
        }
    }
}