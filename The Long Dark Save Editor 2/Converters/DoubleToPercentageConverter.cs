using System;
using System.Globalization;
using System.Windows.Data;

namespace The_Long_Dark_Save_Editor_2.Converters
{
	class DoubleToPercentageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var val = (double) value;

			val = Math.Round(val * 100);
			return val + "%";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}
