using System;
using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Grabby_Two.Model
{
    public class IndicatorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int currentIndex = (int)value;
            int index = int.Parse(parameter.ToString());

            return currentIndex == index ? Colors.Purple : Colors.Gray; // Active color: Purple, Inactive color: Gray
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}