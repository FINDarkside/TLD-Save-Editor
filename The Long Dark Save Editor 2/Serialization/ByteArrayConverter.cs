using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace The_Long_Dark_Save_Editor_2.Serialization
{
    /* 
     * TLD serializes byte arrays as arrays of numbers, but JSON.net default behavior serializes
     * them as base64 strings. That's why we need custom converter. Using base64 would reduce TLD
     * save file sizes by ~50% btw...
     */
    public class ByteArrayConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var data = (byte[])value;
            writer.WriteStartArray();
            for (int i = 0; i < data.Length; i++)
            {
                writer.WriteValue(data[i]);
            }
            writer.WriteEndArray();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }

    }

}
