using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Markup;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
	public class EnumerationExtension : MarkupExtension
	{
		private Type _enumType;

		public EnumerationExtension(Type enumType)
		{
			if (enumType == null)
				throw new ArgumentNullException("enumType");
			EnumType = enumType;
		}

		public Type EnumType
		{
			get { return _enumType; }
			private set
			{
				if (_enumType == value)
					return;

				var enumType = Nullable.GetUnderlyingType(value) ?? value;
				if (enumType.IsEnum == false)
					throw new ArgumentException("Type must be an Enum.");

				_enumType = value;
			}
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			var enumValues = Enum.GetValues(EnumType);

			return (
			  from object enumValue in enumValues
			  select new EnumerationMember
			  {
				  Value = enumValue,
				  Description = GetDescription(enumValue)
			  }).ToArray();
		}

		public static string GetDescription(object enumValue)
		{
			var key = enumValue.GetType().Name + "_" + enumValue;
			string desc = Properties.Resources.ResourceManager.GetString(key) ?? enumValue.ToString();
			return desc;
		}

	}

	public class EnumerationMember
	{
		public string Description { get; set; }
		public object Value { get; set; }
	}
}
