using System;
using System.Globalization;
using System.Windows.Data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Converters
{
	class PrefabNameConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var gearName = value as string;
			if (gearName == null)
				return "";

			return ItemDictionary.GetInGameName(gearName);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}
