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

        private Dictionary<object, JToken> extraFields = new Dictionary<object, JToken>();
        public T Obj { get; private set; }

        public DynamicSerializable(string json)
        {
            Obj = Parse(JObject.Parse(json), typeof(T));
        }

        private dynamic Parse(JToken token, Type t, bool deserialize = false)
        {
            if (token.Type == JTokenType.Object)
            {
                return ParseObject((JObject)token, t);
            }
            else if (token.Type == JTokenType.Array)
            {
                return ParseArray((JArray)token, t);
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
                return Parse(JToken.Parse(s), t);
            }
            else if (token.Type == JTokenType.Null)
            {
                return null;
            }
            else
            {
                throw new Exception("Invalid token type " + t);
            }
        }

        private object ParseObject(JObject obj, Type t)
        {
            var result = Activator.CreateInstance(t);
            Dictionary<string, PropertyInfo> props = t.GetProperties().ToDictionary(p => MemberToName(p));
            Dictionary<string, FieldInfo> fields = t.GetFields().ToDictionary(p => MemberToName(p));

            foreach (var child in obj)
            {
                if (props.ContainsKey(child.Key))
                {
                    var prop = props[child.Key];
                    var attr = prop.GetCustomAttribute<DeserializeAttribute>();
                    var childType = prop.PropertyType;
                    var childVal = Parse(child.Value, childType, attr != null && attr.Json);
                    prop.SetValue(result, childVal);
                }
                else if (fields.ContainsKey(child.Key))
                {
                    var field = fields[child.Key];
                    var attr = field.GetCustomAttribute<DeserializeAttribute>();
                    var childType = field.FieldType;
                    var childVal = Parse(child.Value, childType, field.GetCustomAttribute<DeserializeAttribute>() != null);
                    field.SetValue(result, childVal);
                }
                else
                {
                    extraFields.Add(result, child.Value);
                }
            }
            return result;
        }

        private object ParseArray(JArray obj, Type t)
        {
            Array result = Array.CreateInstance(t, obj.Count);
            int i = 0;
            foreach (var child in obj)
            {
                result.SetValue(Parse(child, t.GetElementType()), i++);
            }
            return result;
        }

        private string MemberToName(MemberInfo m)
        {
            var attr = m.GetCustomAttribute<DeserializeAttribute>();
            if (attr != null)
                return attr.From;
            return m.Name;
        }
    }
}
