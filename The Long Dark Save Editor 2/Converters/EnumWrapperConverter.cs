using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using The_Long_Dark_Save_Editor_2.Helpers;
using System.Linq;

namespace The_Long_Dark_Save_Editor_2.Converters
{
    public class EnumWrapperConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumWrapper = (EnumWrapper) value;
            var enumName = enumWrapper.GetType().GetGenericArguments()[0].Name;

            return enumWrapper.Values.Select(s => new EnumerationMember
            {
                Value = s,
                Description = Properties.Resources.ResourceManager.GetString(enumName + "_" + s) ?? s
            }).ToArray();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
