using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
namespace SpartaHack.MVVM
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, string language) =>
            (bool)value ^ (parameter as string ?? string.Empty).Equals("Reverse") ?
                Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            (Visibility)value == Visibility.Visible ^ (parameter as string ?? string.Empty).Equals("Reverse");

    }
    public class NegateBooleanToVisibilityConverter :BooleanToVisibilityConverter
    {
        public override object  Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ^ (parameter as string ?? string.Empty).Equals("Reverse") ?
                Visibility.Collapsed : Visibility.Visible;
        }

        
    }
}
