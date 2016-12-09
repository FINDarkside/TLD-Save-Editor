using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace The_Long_Dark_Save_Editor_2.Converters
{
	class InjuriesToOpacityConverter : IMultiValueConverter
	{

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			int param = (int)parameter;

			foreach (object o in values)
			{
				if (o.GetType() == typeof(bool))
				{
					if ((bool)o)
						return 1d;
				}
				else if (o.GetType() == typeof(int[]))
				{
					int[] arr = (int[])o;
					if (arr.Contains(param))
						return 1d;
				}
			}
			return 0d;
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}


	}
}
