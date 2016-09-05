using Newtonsoft.Json;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
	public static class Util
	{
		public static T DeserializeObject<T>(string json) where T : class
		{

			if (json == null)
				return null;

			return JsonConvert.DeserializeObject<T>(json);
		}

		public static string SerializeObject(object o)
		{
			if (o == null)
				return null;
			return JsonConvert.SerializeObject(o);
		}
	}
}
