using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Grabby_Two.Model
{
    public class IndicatorConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null || !(value is int currentIndex) || !(parameter is int indicatorIndex))
                return Colors.Gray; // Default color for inactive indicators

            return currentIndex == indicatorIndex ? Colors.Purple : Colors.Gray;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
