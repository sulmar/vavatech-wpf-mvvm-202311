using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfClient.Converters;

internal class BooleanToVisibilityConverter : IValueConverter
{
    public Visibility FalseValue { get; set; } = Visibility.Collapsed;
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : FalseValue;
        }

        throw new InvalidCastException();

    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
