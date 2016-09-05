using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using The_Long_Dark_Save_Editor_2.Game_data;
using The_Long_Dark_Save_Editor_2.Helpers;

namespace The_Long_Dark_Save_Editor_2.Converters
{
	class CategoryToItemsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || value.GetType() != typeof(ItemCategory))
				return null;

			var cat = (ItemCategory)value;


			var result = new List<EnumerationMember>();
			foreach (KeyValuePair<string, ItemInfo> entry in ItemDictionary.itemInfo)
			{
				if (entry.Value.category == cat)
				{
					var member = new EnumerationMember() { Value = entry.Key, Description = entry.Value.inGameName };
					result.Add(member);
				}

			}
			result = result.OrderBy(item => item.Description).ToList();
			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}
}
