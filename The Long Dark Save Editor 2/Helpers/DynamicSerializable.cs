using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace The_Long_Dark_Save_Editor_2.Helpers
{
    public class DynamicSerializable<T> where T : new()
    {

        private Dictionary<string, JToken> extraFields = new Dictionary<string, JToken>();
        public T Obj { get; private set; }

        public DynamicSerializable(string json, string path = "")
        {
            Obj = Parse(JObject.Parse(json), typeof(T), typeof(T).ToString());
        }

        private dynamic Parse(JToken token, Type t, string path, bool deserialize = false)
        {
            if (token.Type == JTokenType.Object)
            {
                if (!t.IsSubclassOf(typeof(object)))
                    throw new Exception(path + " is not an object");
                return ParseObject((JObject)token, t, path);
            }
            else if (token.Type == JTokenType.Array)
            {
                if (!t.IsArray)
                    throw new Exception(path + " is not an array");
                return ParseArray((JArray)token, t, path);
            }
            else if (token.Type == JTokenType.Boolean || token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject(t);
            }
            else if (token.Type == JTokenType.String)
            {
                string s = token.ToObject<string>();
                if (!deserialize)
                    return s;
                return Parse(JToken.Parse(s), t, path);
            }else if(token.Type == JTokenType.Null)
            {
                return null;
            }
            else
            {
                throw new Exception("Invalid token type " + t);
            }
        }

        private object ParseObject(JObject obj, Type t, string path)
        {
            var result = Activator.CreateInstance(t);
            Dictionary<string, PropertyInfo> props = t.GetProperties().ToDictionary(p => p.Name);
            Dictionary<string, FieldInfo> fields = t.GetFields().ToDictionary(p => p.Name);

            foreach (var child in obj)
            {
                if (props.ContainsKey(child.Key))
                {
                    var prop = props[child.Key];
                    var childType = prop.PropertyType;
                    var childVal = Parse(child.Value, childType, path + "." + child.Key, prop.GetCustomAttribute<DeserializeAttribute>() != null);
                    prop.SetValue(result, childVal);
                }
                else if (fields.ContainsKey(child.Key))
                {
                    var field = fields[child.Key];
                    var childType = field.FieldType;
                    var childVal = Parse(child.Value, childType, path + "." + child.Key, field.GetCustomAttribute<DeserializeAttribute>() != null);
                    field.SetValue(result, childVal);
                }
                else
                {
                    extraFields.Add(path + "." + child.Key, child.Value);
                }
            }
            return result;
        }

        private object ParseArray(JArray obj, Type t, string path)
        {
            Array result = Array.CreateInstance(t, obj.Count);
            int i = 0;
            foreach (var child in obj)
            {
                result.SetValue(Parse(child, t.GetElementType(), path + ".[]"), i++);
            }
            return result;
        }

    }
}
