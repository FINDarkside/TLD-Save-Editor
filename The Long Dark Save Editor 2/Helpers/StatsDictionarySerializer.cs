using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
	public class StatsDictionarySerializer : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return (objectType == typeof(Dictionary<int, string>));
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			Debug.WriteLine("---------------");

			while (reader.Read())
			{
				Debug.WriteLine(reader.Value);
			}

			JObject obj = JObject.Load(reader);
			var d = new Dictionary<int, string>();
			foreach (var child in obj)
			{
				int key = int.Parse(child.Key);
				d.Add(key, child.Value.ToString());
			}

			return d;
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}

	}
}
