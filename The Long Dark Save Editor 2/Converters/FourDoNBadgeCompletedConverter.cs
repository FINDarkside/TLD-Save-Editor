using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace The_Long_Dark_Save_Editor_2.Converters
{
    public class FourDoNBadgeCompletedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<bool> l = value as List<bool>;
            if (l == null)
                return false;
            return l.Count == 4 && l[0] && l[1] && l[2] && l[3];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            if (b)
                return new List<bool>() { true, true, true, true };
            else
                return new List<bool>() { false, false, false, false };
        }
    }
}
