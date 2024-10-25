using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Grabby_Two.Model
{
    public class BooleanToObjectConverter<T> : IValueConverter
    {
        public T ? FalseObject { set; get; }
        public T ? TrueObject { set; get; }

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (value is bool boolValue) && boolValue ? TrueObject : FalseObject;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is T typedValue)
            {
                return Equals(typedValue, TrueObject);
            }
            return false;
        }
    }
}
